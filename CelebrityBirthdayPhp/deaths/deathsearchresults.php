<?php
/*
 * HINDLEWARE
 * Copyright (C) 2020-23 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
sec_session_start();
$currentPage = 'deaths';
$formKey = new formKey();
$key = $formKey->outputKey();
$deathyear = date('Y');
$persons = [];
if (login_check($mypdo) == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        if (! isset($_POST['form_key']) || ! $formKey->validate()) {
            header('Location: ' . $myPath . 'index.php?error=1');
        } else {
            if (isset($_POST['deathyear'])) {
                $deathyear = trim($_POST['deathyear']);
            }
        }
    }
    if (isset($deathyear)) {
           
            $personsql = "SELECT birthday, birthmonth, birthyear, forename, id, longdesc, shortdesc, surname, deathday, deathmonth, deathyear
                            FROM Person
                            WHERE (deathyear = :deathyear)
                            ORDER BY deathyear, deathmonth, deathday, surname, forename";
            $personquery = $mypdo->prepare($personsql);
            $personquery->bindParam(":deathyear",$deathyear);
            $personquery->execute();
            $persons = $personquery->fetchAll(PDO::FETCH_ASSOC);
            
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
                <link rel="icon" type="image/x-icon" href="/mynovel/favicon.ico"/>
                <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
			    <script src="/hindleware/js/jquery.js"></script>
			    <script src="/hindleware/js/jquery.tablesorter.js"></script>
			    <script>
		            $(function(){
		            $(\'#deaths\').tablesorter({
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
                        <h2 style="color:#000080";>Selected Deaths</h2>
                    </div>
                       <div class="box" style="padding:1em;margin:10px;width:700px;">

	                	<form class="form" role="form" name ="editperson" method="post" action=" ' . $myPath . 'person/edit-person.php">';
    $html .= $key;
    $html .= '	
                            <div>
    				        	<table class="table table-bordered" id="deaths">
    								<thead>
    								<tr>
    									<th style="width:10%;text-align:center;">Id</th>
    									<th style="width:10%">Birth Date</th>
                                        <th style="width:15%">Forenames</th>
                                        <th style="width:15%">Surname</th>
                                        <th style="width:40%">Description</th>
                                        <th style="width:10%">Death Date</th>
    								</tr>
    								</thead>
    								<tbody>
									';
    if ($persons) {
        foreach ($persons as $rs) {
            $html .= '
    									<tr>
                                            <td><button type="submit" name="personid" value="' . $rs['id'] . '">' . $rs['id'] . '</button></td>
    										<td>' . sprintf('%02d',$rs['birthday']) . '/' . sprintf('%02d',$rs['birthmonth']) . '/' .  $rs['birthyear'] . '</td>
    										<td>' . $rs['forename'] . '</td>
    										<td>' . $rs['surname']  . '</td>
    										<td>' . $rs['shortdesc'] . '</td>
                                            <td>' . sprintf('%02d',$rs['deathday']) . '/' . sprintf('%02d',$rs['deathmonth']) . '/' .  $rs['deathyear'] . '</td>
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
