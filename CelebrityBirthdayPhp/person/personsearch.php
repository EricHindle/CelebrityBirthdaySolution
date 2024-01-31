<?php
/*
 * HINDLEWARE
 * Copyright (C) 2023 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';

sec_session_start();
$formKey = new formKey();

$currentPage = 'people';
$key = $formKey->outputKey();
$html = '';
$updtype = 'update';
$h3 = 'Search for Person';
if (login_check() == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'GET') {
        if (isset($_GET['u'])) {
            $updtype = $_GET['u'];
        }
    }

    if ($updtype == 'death') {
        $h3 = 'Person who died';
        $currentPage = 'deaths';
    }
    echo '
		<!doctype html>
		<html>
			<head>
                <meta charset="UTF-8" />
                <title>Celebrity Birthdays</title>
                <meta name="viewport" content="width=device-width, initial-scale=1.0" />
			    <link rel="stylesheet" href="/hindleware/css/style.css">
                <link rel="icon" type="image/x-icon" href="/celebbirthday/favicon.ico"/>
                <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
			</head>
			        
			<body>';
    include $myPath . 'globNAV.php';
    $html .= '
                 <div class="container" style="min-height:30vh;">
                        <div class="box" style="padding:1em;padding-left:2%;padding-right:2%;margin:10px;">
                            <h3 class="text-center">' . $h3 . '</h3>
                            <form class="form-horizontal" role="form" name ="searchname" method="post" action="searchresults.php">';
    $html .= $key;
    $html .= '
                                <div class="form-group">
                                    <label class="form-text" style="">Name:</label>
                                    <input type="text" class="form-field-slim" id="personname" name="personname" value=""><br>
                                    <input type="hidden" id="updtype" name="updtype" value="' . $updtype . '">
                                </div>
				                <div class="form-group">
                                    <input id="submit" name="submit" type="submit" value="Search" class="btn bluebutton" style="padding:5px;width:50%;">
 	                            </div>
                            </form>
                        </div>
                        <div class="box" style="padding:1em;padding-left:2%;padding-right:2%;margin:10px;">
                            <h3 class="text-center">Search for Birthday</h3>
                            <form class="form-horizontal" role="form" name ="searchname" method="post" action="birthdaylist.php">';
    $html .= $key;
    $html .= '
                                <div class="form-group">
                                    <label class="form-text" style="">Day:</label>
                                    <input type="text" class="form-field-slim" id="birthday" name="birthday" value="' . date('d') . '"><br>
                                    <label class="form-text" style="">Month:</label>
                                    <input type="text" class="form-field-slim" id="birthmonth" name="birthmonth" value="' . date('m') . '"><br>
                                </div>
				                <div class="form-group">
                                    <input id="submit" name="submit" type="submit" value="Search" class="btn bluebutton" style="padding:5px;width:50%;">
 	                            </div>
                            </form>
                        </div>
                    </div>
                </body>
            </html>';
    echo $html;
} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}

?> 