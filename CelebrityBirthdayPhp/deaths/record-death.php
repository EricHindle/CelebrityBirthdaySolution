<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$myPath = '../';

require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
require '../person/personfunctions.php';

sec_session_start();
$currentPage = 'deaths';
$formKey = new formKey();
$personname = '';
if (login_check() == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        if (! isset($_POST['form_key']) || ! $formKey->validate()) {
            header('Location: ' . $myPath . 'index.php?error=1');
        } else {
            if (isset($_POST['personname'])) {
                $personname = $_POST['personname'];
            }
            if (isset($_POST['personid'])) {
                $personid = sanitize_int($_POST['personid']);
                if ($personid) {
                    $html = "";
                    $person = getperson($personid);
                    if (isset($person)) {
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
                                            <h2>' . $person['forename'] . ' ' . $person['surname'] . '</h2>
                                        </div>
                                        <div class="box" style="padding:1em;margin:10px;">
                                            <form role="form" name ="recorddeath" method="post" action="process-death.php">';
                        $html .= $key;
                        $dob = $person['birthday'] . '-' . $person['birthmonth'] . '-' . $person['birthyear'];
                        $fdob =  date("j F Y", strtotime($dob));
                        $dod = '';
                        $fdod = '';
                        if ($person['deathyear'] > 0) {
                            $dod = $person['deathday'] . '-' . $person['deathmonth'] . '-' . $person['deathyear'];
                            $fdod = date("j F Y", strtotime($dod));
                        }
                        $html .= '
                                <div class="form-group"  style="padding-left:10px;text-align:left;">
                                       <label class="form-text" >Description:</label><br>
                                        <div class="box" style="padding:10px;text-align:justify;width:100%;">
                                           ' . $person['longdesc'] . '
                                        </div>';
                        $temp1 = explode("(", $person['longdesc'], 2);
                        $temp2 = explode(")", $temp1[1], 2);
                        $newdesc = $temp1[0] . '(' . $fdob . ' - ' . $fdod . ')' . $temp2[1];
                        $newdesc = str_replace(' is ', ' was ', $newdesc);
                        $html .= '      <br>
                                        <label class="form-text" >Date of birth:</label>' . $dob . '<br>
                                        <label class="form-text" >Date of death:</label>
                                        <input type="text" class="form-field-slim" id="dod" name="dod" value="' . $dod . '"><br>
                                        <label class="form-text" style="">Description:</label>
                                        <textarea class="form-field-slim" id="description" name="description" rows=2 cols=25 >'. $newdesc .' </textarea><br>
                                ';
                        $html .= '      <input type= "hidden" name= "personid" value="' . $personid . '" />
        					        </div>
                                    <div class="form-group" style="padding-top:25px;text-align:center">
        					            <input id="submit" name="submit" type="submit" value="Submit" class="btn bluebutton" style="padding:5px;width:50%;">
        					        </div>
        		                </form>
                                <div class="light-text">
        				            <a href="' . $myPath . 'person/searchresults.php?personname=' . $personname . '&updtype=death">Back</a>
        				        </div>
        		            </div>
        		        </div>
        			</body>
              </html>';
                    } else {
                        $html .= "<script>
										alert('There was a problem. Please check details and try again.');
										window.location.href='selectperson.php';
									</script>";
                    }
                    echo $html;
                } else {
                    echo "<script>
								alert('There was a problem. Please check details and try again.');
								window.location.href='selectperson.php';
							</script>";
                }
            } else {
                header('Location: ' . $myPath . 'index.php?error=1');
            }
        }
    } else {
        header('Location: ' . $myPath . 'index.php?error=1');
    }
} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}
?>