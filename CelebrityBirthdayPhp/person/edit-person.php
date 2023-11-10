<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$myPath = '../';

require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
require 'personfunctions.php';

sec_session_start();
$currentPage = 'people';
$formKey = new formKey();
$personname = '';

$typesql = "SELECT * FROM CelebrityTypes ORDER BY celebTypeId ASC";
$typequery = $mypdo->prepare($typesql);
$typequery->execute();
$types = $typequery->fetchAll(PDO::FETCH_ASSOC);

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
                    if (isset($person)){
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
                                            <h2>' . $person['forename'] . ' ' .$person['surname'] . '</h2>
                                        </div>
                                        <div class="box" style="padding:1em;margin:10px;">
                                            <form role="form" name ="editperson" method="post" action="process-edit-person.php">';
                        $html .= $key;
                        $dob = $person['birthday'] . '/' . $person['birthmonth'] . '/' .  $person['birthyear'];
                        $dod = '';
                        if ($person['deathyear'] > 0) {
                          $dod = $person['deathday'] . '/' . $person['deathmonth'] . '/' .  $person['deathyear'];
                        }
                        $selected = '';
                        $html .= '
                                                <div class="form-group"  style="padding-left:10px;text-align:left;">
                                                    <label class="form-text" style="">New forename:</label>
                                                    <input type="text" class="form-field-slim" id="forename" name="forename" value="' . $person['forename'] . '"><br>
                                                    <label class="form-text" style="">New surname:</label>
                                                    <input type="text" class="form-field-slim" id="surname" name="surname" value="' . $person['surname'] . '"><br>
                                                    <label class="form-text"  style="">Full birth name:</label>    
                                                    <input type="text" class="form-field-slim" id="birthname" name="birthname" value="' . $person['birthname'] . '"><br>
                                                    <label class="form-text"  style="">Date of birth:</label>    
                                                    <input type="text" class="form-field-slim" id="dob" name="dob" value="' . $dob . '"><br>
                                                    <label class="form-text"  style="">Date of death: </label>
                                                    <input type="text" class="form-field-slim" id="dod" name="dod" value="' . $dod . '"><br>
                                                    <label class="form-text"  style="">Short description: </label>
                                                    <input type="text" class="form-field-slim" id="shortdesc" name="shortdesc" value="' . $person['shortdesc'] . '"><br>
                                                    <label class="form-text" style="">Description:</label>
                                                    <textarea class="form-field-slim" id="description" name="description"  rows=2 cols=25 >'. $person['longdesc'] .' </textarea><br>
                                                    <label class="form-text"  style="">Celeb Type: </label>
                                                    <select class="form-field-slim" id="celebtypeid" name="celebtypeid">';
                                                        foreach ($types as $type) {
                                                            $selected = '';
                                                            if ( $person['celebtype'] == $type['celebTypeId']) {
                                                                $selected = 'selected';
                                                            }
                                                            $html .= '              <option value="' . $type['celebTypeId'] . '" ' . $selected . '>' . $type['celebTypeDesc'] . '</option>';
                                                        }
                                                        $html .= '	        
                                                    </select><br>
                                                    <input type= "hidden" name= "personid" value="' . $personid . '" />
                                                    <a class = "lightbtn" href="' . $myPath . 'reminder/addreminder.php?personid=' . $personid  . '">Add a reminder</a>
                    					        </div>
                                                <div class="form-group" style="padding-top:25px;text-align:center">
                    					            <input id="submit" name="submit" type="submit" value="Submit" class="btn bluebutton" style="padding:5px;width:50%;">
                    					        </div>
                    		                </form>

                    				          
                                            <div class="light-text">
                    				            <a href="' . $myPath . 'person/searchresults.php?personname='.  $personname  .'">Back</a>
                    				        </div>
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