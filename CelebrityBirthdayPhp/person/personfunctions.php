<?php
/*
 * HINDLEWARE
 * Copyright (C) 2023 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require_once $myPath . 'includes/db_connect.php';

function getperson($personid) 
{
    global $mypdo;
    $person = '';
    $personsql = "SELECT * FROM fullperson WHERE id = :id";
    $personquery = $mypdo->prepare($personsql);
    $personquery->bindParam(':id', $personid, PDO::PARAM_INT);
    $personquery->execute();
    $person = $personquery->fetch(PDO::FETCH_ASSOC);
    return $person;
}

function insertperson($forename, $surname, $description, $shortdesc, $birthname, $dob, $dod)
{
    global $mypdo;
    $birthdate = getdate(strtotime($dob));
    $bday = $birthdate['mday'];
    $bmonth = $birthdate['mon'];
    $byear = $birthdate['year'];
    $deathdate = '';
    $dday = '';
    $dmonth = '';
    $dyear = '';
    $insdod1 = '';
    $insdod2 = '';
    if (isset($dod) && $dod != '') {
        $deathdate = getdate(strtotime($dod));
        $dday = $deathdate['mday'];
        $dmonth = $deathdate['mon'];
        $dyear = $deathdate['year'];
        $insdod1 = ", deathday, deathmonth, deathyear";
        $insdod2 = ", :dday, :dmonth, :dyear";
    }
    
    $sqladdperson = "INSERT INTO person 
        (name, forename, surname, shortdesc, longdesc, birthname, birthday, birthmonth, birthyear" . $insdod1 . ") 
        VALUES 
        (:name, :forename, :surname, :shortdesc, :longdesc, :birthname" . $insdod2 . ")";
    $stmtaddperson = $mypdo->prepare($sqladdperson);
    $stmtaddperson->bindParam(':forename', $forename);
    $stmtaddperson->bindParam(':surname', $surname);
    $stmtaddperson->bindParam(':shortdesc', $shortdesc);
    $stmtaddperson->bindParam(':description', $description);
    $stmtaddperson->bindParam(':birthname', $birthname);
    if (isset($dod) && $dod != '') {
        $stmtaddperson->bindParam(':dday', $dday, PDO::PARAM_INT);
        $stmtaddperson->bindParam(':dmonth', $dmonth, PDO::PARAM_INT);
        $stmtaddperson->bindParam(':dyear', $dyear, PDO::PARAM_INT);
    }
    $stmtaddperson->bindParam(':bday', $bday, PDO::PARAM_INT);
    $stmtaddperson->bindParam(':bmonth', $bmonth, PDO::PARAM_INT);
    $stmtaddperson->bindParam(':byear', $byear, PDO::PARAM_INT);
    
    $stmtaddperson->execute();
    $added = $stmtaddperson->rowCount();
    return $added;
}

function updateperson($personid, $forename, $surname, $shortdesc, $description, $birthname, $dob, $dod, $celebtypeid)
{
    global $mypdo;
    $birthdate = getdate(strtotime(str_replace('/', '-',$dob)));
    $bday = $birthdate['mday'];
    $bmonth = $birthdate['mon'];
    $byear = $birthdate['year'];
    $deathdate = '';
    $dday = 0;
    $dmonth = 0;
    $dyear = 0;
    if (isset($dod)) {
        if ($dod != '') {
        $deathdate = getdate(strtotime(str_replace('/', '-',$dod)));
        $dday = $deathdate['mday'];
        $dmonth = $deathdate['mon'];
        $dyear = $deathdate['year'];
        }
    }
    $sqlupdperson = "UPDATE person
        SET
        surname = :surname,
        forename = :forename,
        longdesc = :description,
        shortdesc = :shortdesc,
        birthname = :birthname,
        birthday = :bday,
        birthmonth = :bmonth,
        birthyear = :byear,
        deathday = :dday,
        deathmonth = :dmonth,
        deathyear = :dyear
        WHERE Id = :personid";
    $stmtupdperson = $mypdo->prepare($sqlupdperson);
    $stmtupdperson->bindParam(':forename', $forename);
    $stmtupdperson->bindParam(':surname', $surname);
    $stmtupdperson->bindParam(':shortdesc', $shortdesc);
    $stmtupdperson->bindParam(':description', $description);
    $stmtupdperson->bindParam(':birthname', $birthname);
    $stmtupdperson->bindParam(':dday', $dday, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':dmonth', $dmonth, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':dyear', $dyear, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':bday', $bday, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':bmonth', $bmonth, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':byear', $byear, PDO::PARAM_INT);

    $stmtupdperson->bindParam(':personid', $personid, PDO::PARAM_INT);
    $stmtupdperson->execute();
    $updated = $stmtupdperson->rowCount();
    
    $sqlsocial = "UPDATE SocialMedia 
        SET
        celebtype = :celebtype
        WHERE personId = :personid";
    $stmtsocial = $mypdo->prepare($sqlsocial);
    $stmtsocial->bindParam(':celebtype', $celebtypeid, PDO::PARAM_INT);    
    $stmtsocial->bindParam(':personid', $personid, PDO::PARAM_INT);    
    $stmtsocial->execute();
    return $updated;
}

function processperson($action)
{
    global $mypdo;
    $html = '';
    if (isset($_POST['surname'], $_POST['description'])) {
        $personid = - 1;
        $forename = '';
        $surname = $_POST['surname'];
        $description = $_POST['description'];
        $birthname = '';
        $shortdesc = '';
        $dob = '';
        $dod = '';
        $celebtypeid = 0;
        
        if (isset($_POST['forename'])) {
            $forename = $_POST['forename'];
        }
        if (isset($_POST['birthname'])) {
            $birthname = $_POST['birthname'];
        }
        if (isset($_POST['shortdesc'])) {
            $shortdesc = $_POST['shortdesc'];
        }
        if (isset($_POST['personid'])) {
            $personid = $_POST['personid'];
        }
        if (isset($_POST['dob'])) {
            $dob = $_POST['dob'];
        }
        if (isset($_POST['dod'])) {
            $dod = $_POST['dod'];
        }

        if (isset($_POST['celebtypeid'])) {
            $celebtypeid = $_POST['celebtypeid'];
        }
        
        if ($forename && $surname && $description) {
            $html = "";

            if ($action == 'create') {

                $added = insertperson($forename, $surname, $description, $shortdesc, $birthname, $dob, $dod);
                $name = $forename . ' ' . $surname;
                if ($added == 1) {
                    $personid = $mypdo->lastInsertId();
                    $html .= "<script>
            						alert('" . $name . " : Person added.');
            						window.location.href='personsearch.php';
    					      </script>";
                } else {
                    $html .= "<script>
        						alert('" . $name . " : Person NOT added.');
        						window.location.href='personsearch.php';
    					      </script>";
                }
            } else {
                $updated = updateperson($personid, $forename, $surname, $shortdesc, $description, $birthname, $dob, $dod, $celebtypeid);
                $name = $forename . ' ' . $surname;
                if ($updated == 1) {
                    $html .= "<script>
            						alert('" . $name . " : Person updated.');
            						window.location.href='personsearch.php';
    					      </script>";
                } else {
                    $html .= "<script>
        						alert('" . $name . " : Person NOT updated.');
        						window.location.href='personsearch.php';
    					      </script>";
                }
            }
        } else {
            $html = "<script>
						alert('There was a problem. Please check details and try again.');
						window.location.href='personsearch.php';
					  </script>";
        }
    }
    return $html;
}
?>