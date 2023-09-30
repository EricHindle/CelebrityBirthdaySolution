<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */

require 'db_connect.php';

date_default_timezone_set('Europe/London');

function sanitize_int($integer, $min = '', $max = '')
{
    $int = intval($integer);
    if ((($min != '') && ($int < $min)) || (($max != '') && ($int > $max))) {
        return FALSE;
    }
    
    return $int;
}

function isSecure()
{
    $docker_is_secure = getenv('FSV_SECURE');
    if ($docker_is_secure == "true") {
        return true;
    } elseif ($docker_is_secure == "false") {
        return false;
    }
    // if env variable not set, detect
    return (! empty($_SERVER['HTTPS']) && $_SERVER['HTTPS'] !== 'off') || $_SERVER['SERVER_PORT'] == 443;
}

function sec_session_start()
{
    $session_name = 'ret_session_id';
    $secure = isSecure();
    // $secure = true; //USUALLY TRUE but false for retail-lamp
    $httponly = true;
    if (ini_set('session.use_only_cookies', 1) === FALSE) {
        error_log("ini_set error in functions", 0);
        header("Location: ../index.php?error=1");
        exit();
    }
    $cookieParams = session_get_cookie_params();
    session_set_cookie_params($cookieParams["lifetime"], $cookieParams["path"], $cookieParams["domain"], $secure, $httponly);
    session_name($session_name);
    session_start();
    session_regenerate_id(true);
}

function check_password($username, $password)
{
    global $mypdo;
    $sql = "SELECT user_id, user_login, user_password, user_forename, user_surname  FROM users WHERE user_login = :username LIMIT 1";
    $query = $mypdo->prepare($sql);
    $query->execute(array(
        ':username' => $username
    ));
    $fetch = $query->fetch(PDO::FETCH_ASSOC);
    if ($fetch) {
        $db_password = $fetch['user_password'];
   //     $db_password = password_hash("abcdef", PASSWORD_DEFAULT);
        $check = password_verify($password, $db_password);
        if ($check) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}

function gettemppassword($playerid)
{
    global $mypdo;
    $temppwdsql = "SELECT * FROM user_temp_password WHERE user_id = :id LIMIT 1";
    $temppwdquery = $mypdo->prepare($temppwdsql);
    $temppwdquery->execute(array(
        ':id' => $playerid
    ));
    $temppwd = $temppwdquery->fetch(PDO::FETCH_ASSOC);
    return $temppwd;
}

function removetemppassword($playerid)
{
    global $mypdo;
    $delsql = "DELETE FROM user_temp_password WHERE user_id=:player";
    $delquery = $mypdo->prepare($delsql);
    $delquery->bindParam(":player", $playerid, PDO::PARAM_INT);
    $delquery->execute();
}

function login($username, $password)
{
    global $mypdo;
    $sql = "SELECT user_id, user_login, user_password, user_forename, user_surname FROM users WHERE user_login = :username";
    $query = $mypdo->prepare($sql);
    $query->execute(array(
        ':username' => $username
    ));
    $fetch = $query->fetch(PDO::FETCH_ASSOC);

    if ($fetch) {
        $user_id = $fetch['user_id'];
        $username = $fetch['user_login'];
        $db_password = $fetch['user_password'];
        $fname = $fetch['user_forename'];
        $sname = $fetch['user_surname'];
        // Check if the password in the database matches
   //     $db_password = password_hash("abcdef", PASSWORD_DEFAULT);
        $check = password_verify($password, $db_password);
  /*      $temppwd = gettemppassword($user_id);

        if (! $check) {
            If ($temppwd) {
                $db_password = $temppwd['user_temp_password'];
                $check = password_verify($password, $db_password);
            }
        } */

        if ($check) {
       //      Password is correct!
       //    removetemppassword($user_id);
            $_SESSION['user_id'] = $user_id;
            $_SESSION['username'] = $username;
            $_SESSION['fname'] = $fname;
            $_SESSION['sname'] = $sname;
            $_SESSION['book_name'] = '';
            if (getenv('HTTP_X_REAL_IP')) {
                $ip = getenv('HTTP_X_REAL_IP');
            } else {
                $ip = $_SERVER['REMOTE_ADDR'];
            }
            $userAgent = getenv('HTTP_USER_AGENT');

            $hash = password_hash($ip . $userAgent, PASSWORD_DEFAULT, [
                'cost' => 5
            ]);
            $_SESSION['login_string'] = $hash;

            date_default_timezone_set('Europe/London');
            $phptime = time();
            $mysqltime = date("Y-m-d H:i:s", $phptime);

            // Login successful.
            return true;
       } else {

            return false;
        }
    } else {
        return false;
    }
}

function login_check()
{
    global $mypdo;
    $err = false;
    if ($err == false) {
        if (isset($_SESSION['user_id'], $_SESSION['username'], $_SESSION['login_string'], $_SESSION['fname'], $_SESSION['sname'], $_SESSION['book_name'])) {
            $user_id = $_SESSION['user_id'];
            $login_string = $_SESSION['login_string'];
            $username = $_SESSION['username'];
            if (getenv('HTTP_X_REAL_IP')) {
                $ip = getenv('HTTP_X_REAL_IP');
            } else {
                $ip = $_SERVER['REMOTE_ADDR'];
            }
            $userAgent = getenv('HTTP_USER_AGENT');
            $login_check = $ip . $userAgent;
            $check = password_verify($login_check, $login_string);
            date_default_timezone_set('Europe/London');
            $phptime = time();
            $mysqltime = date("Y-m-d H:i:s", $phptime);

            if ($check) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    } else {
        return false;
    }
}

function get_global_value($valuename)
{
    global $mypdo;
    $infosql = "SELECT pvalue FROM settings WHERE pkey = :valname";
    $infoquery = $mypdo->prepare($infosql);
    $infoquery->bindParam(':valname', $valuename);
    $infoquery->execute();
    $infofetch = $infoquery->fetch(PDO::FETCH_ASSOC);
    return $infofetch['pvalue'];
}

function bootOut($rootPath, $user = 'UNKNOWN', $page = 'UNKNOWN', $error = 'UNKNOWN')
{
    error_log("User: " . $user . ", Page: " . $page . ", Error: " . $error, 0);
    return header('Location: ' . $rootPath . 'index.php?error=1');
}

function generate_password()
{
    $allchars = "abcdefghjkmnpqrstuvwxyz23456789ABCDEFGHJKLMNOPQRSTUVWXYZ";
    $randstr = str_shuffle($allchars);
    $passcode = "";
    for ($i = 1; $i < 9; $i ++) {
        $passcode .= substr($randstr, 0, 1);
        $randstr = str_shuffle($randstr);
    }
    return $passcode;
}


function download($filein){
    if (file_exists($filein)) {
        header('Content-Description: File Transfer');
        header('Content-Type: application/octet-stream');
        header('Content-Disposition: attachment; filename="'.basename($filein).'"');
        header('Expires: 0');
        header('Cache-Control: must-revalidate');
        header('Pragma: public');
        header('Content-Length: ' . filesize($filein));
        readfile($filein);
    }
}
?>
