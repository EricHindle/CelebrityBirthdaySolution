<?php
/*
 * HINDLEWARE
 * Copyright (C) 2023 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
sec_session_start();
$currentPage = 'people';
$formKey = new formKey();
$personname = '';
$updtype = 'update';
$action = 'edit-person.php';
if (login_check($mypdo) == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        if (! isset($_POST['form_key']) || ! $formKey->validate()) {
            header('Location: ' . $myPath . 'index.php?error=1');
        } else {
            if (isset($_POST['personname'])) {
                $personname = trim($_POST['personname']);
            }
            if (isset($_POST['updtype'])) {
                $updtype = $_POST['updtype'];
            }
        }
    } else {
        if (isset($_GET['personname'])) {
            $personname = trim($_GET['personname']);
        }
        if (isset($_GET['updtype'])) {
            $updtype = $_GET['updtype'];
        }
    }
    if ($updtype == 'death') {
        $action = '../deaths/record-death.php';
        $currentPage = 'deaths';
    }
    $key = $formKey->outputKey();
    $forenames = '';
    $surname = '';
    if (isset($personname)) {
        $names = explode(" ", $personname);
        if ($names != '') {
            $surname = end($names) . '%';
            if (count($names) > 1) {
                $farray = explode(" ", $personname, - 1);
                $forenames = implode(" ", $farray);
            }
            $forenames = $forenames . '%';

            $personsql = "SELECT birthday, birthmonth, birthyear, forename, id, longdesc, shortdesc, surname, deathyear
                            FROM Person
                            WHERE (forename LIKE :forename) AND (surname LIKE :surname) OR
                                    (forename LIKE :surname1) AND (surname LIKE :forename1)
                            ORDER BY surname, forename";
            $personquery = $mypdo->prepare($personsql);
            $personquery->bindParam(":forename", $forenames);
            $personquery->bindParam(":surname", $surname);
            $personquery->bindParam(":forename1", $forenames);
            $personquery->bindParam(":surname1", $surname);
            $personquery->execute();
            $persons = $personquery->fetchAll(PDO::FETCH_ASSOC);
        }
    }
    $html = '';
    echo '
		<!doctype html>
		<html>
			<head>
 			    <meta charset="UTF-8">
			    <title>Selected People</title>
			    <meta name="viewport" content="width=device-width, initial-scale=1">
                <link rel="stylesheet" href="/hindleware/css/style.css" type="text/css">
                <link rel="icon" type="image/x-icon" href="/celebbirthday/favicon.ico"/>
                <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
			    <script src="/hindleware/js/jquery.js"></script>
			    <script src="/hindleware/js/jquery.tablesorter.js"></script>
			    <script>
		            $(function(){
		            $(\'#people\').tablesorter({
                        dateFormat : "ddmmyyyy",
                        emptyTo: "emptyMax"
                        });
		            });
		        </script>
			</head>
			        
			<body>';
    include $myPath . 'globNAV.php';

    $html .= '
                <div class="container">
                    <div class="box" style="padding:1em;margin:1em;">
                        <h2 style="color:#000080";>Selected People</h2>
                    </div>
                       <div class="box" style="padding:1em;margin:10px">
    	        		<h3  style="color:#000080";>Select person to edit</h3>
	                	<form class="form" role="form" name ="editperson" method="post" action="' . $action . '">';
    $html .= $key;
    $html .= '	            <input type="hidden" name="personname" value="' . $personname . '" />
                            <div>
    				        	<table class="table table-bordered" id="people">
    								<thead>
    								<tr>
    									<th style="width:10%;text-align:center;">Id</th>
    									<th style="width:10%">Birth Date</th>
                                        <th style="width:15%">Forenames</th>
                                        <th style="width:15%">Surname</th>
                                        <th style="width:50%">Description</th>
    								</tr>
    								</thead>
    								<tbody>
									';
    if ($persons) {
        foreach ($persons as $rs) {
            $isdead = ($rs['deathyear'] > 0);
            if ($isdead) {
                $color = 'steelblue';
            } else {
                $color = '#000080';
            }
            $html .= '
				<tr>
                    <td><button type="submit" name="personid" value="' . $rs['id'] . '">' . $rs['id'] . '</button></td>
					<td>' . sprintf('%02d', $rs['birthday']) . '/' . sprintf('%02d', $rs['birthmonth']) . '/' . $rs['birthyear'] . '</td>
					<td style="color:' . $color . ';">' . $rs['forename'] . '</td>
					<td style="color:' . $color . ';">' . $rs['surname'] . '</td>
					<td>' . $rs['shortdesc'] . '</td>
				</tr>';
        }
    }
    $html .= '
									</tbody>
								</table>
                            </div>
                        </form>
				    </div>';
    $html .= '  </body>
		  </html>';
    echo $html;
} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}
?>
