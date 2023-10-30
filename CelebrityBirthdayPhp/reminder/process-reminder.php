<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$myPath = '../';

require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
require 'reminderfunctions.php';

sec_session_start();
$formKey = new formKey();
if (login_check() == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        if (! isset($_POST['form_key']) || ! $formKey->validate()) {
            header('Location: ' . $myPath . 'index.php?error=1');
        } else {
            $html = '';
            if (isset($_POST['personid'], $_POST['note'])) {
                $personid = $_POST['personid'];
                $note = $_POST['note'];
                $added = insertreminder($personid, $note);
                if ($added == 1) {
                    $html .= "<script>
            						alert('Reminder added.');
            						window.location.href='../menus/home.php';
    					      </script>";
                } else {
                    $html .= "<script>
        						alert('Reminder NOT added.');
        						window.location.href='../menus/home.php';
    					      </script>";
                }
            } else {
                
            }
        }
        echo $html;
    }
} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}
?>