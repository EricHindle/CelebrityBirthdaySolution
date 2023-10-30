<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$myPath = '../';

require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
require $myPath . 'person/personfunctions.php';

sec_session_start();
$currentPage = 'people';
$formKey = new formKey();
$personname = '';
$personid = - 1;
$forename = 'General';
$surname = 'Reminder';
if (login_check() == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'GET') {
        if (isset($_GET['personid'])) {
            $personid = sanitize_int($_GET['personid']);
        }
        if ($personid) {
            $html = "";
            $person = getperson($personid);
            if ($person && isset($person)) {
                $forename = $person['forename'];
                $surname = $person['surname'];
            }
            $key = $formKey->outputKey();

            echo '
							<!doctype html>
							<html>
								<head>									
								    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
								    <meta charset="UTF-8">								    
								    <title>Celebrity Birthday</title>								    
								    <meta name="viewport" content="width=device-width, initial-scale=1">
								    <link rel="stylesheet" href="/hindleware/css/style.css">
                                    <link rel="icon" type="image/x-icon" href="/celebbirthday/favicon.ico"/>
                                    <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
								    <script src="' . $myPath . 'js/jquery.js"></script>
								    <script src="' . $myPath . 'js/bootstrap.min.js"></script>
								</head>
								<body>';
            include $myPath . 'globNAV.php';
            $html .= '
                                    <div class="container">
                                        <div class="box" style="padding:1em;">
                                            <h2>' . $forename . ' ' . $surname . '</h2>
                                        </div>
                                        <div class="box" style="padding:1em;margin:10px;">
                                            <form role="form" name ="reminder" method="post" action="process-reminder.php">';
            $html .= $key;
            $html .= '
                                                <div class="form-group"  style="padding-left:10px;text-align:left;">
                                                    <label class="form-text" style="">Note:</label>
                                                    <textarea class="form-field-slim" id="note" name="note"  rows=2 cols=25 > </textarea><br>
                                                     <input type= "hidden" name= "personid" value="' . $personid . '" />
                    					        </div>
                                                <div class="form-group" style="padding-top:25px;text-align:center">
                    					            <input id="submit" name="submit" type="submit" value="Submit" class="btn bluebutton" style="padding:5px;width:50%;">
                    					        </div>
                    		                </form>
                    		            </div>
                    		        </div>
                    			</body>
                    		</html>  ';
        } else {
            $html .= "<script>
										alert('There was a problem. Please check details and try again.');
										window.location.href='selectperson.php';
									</script>";
        }
        echo $html;
    }

} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}
?>