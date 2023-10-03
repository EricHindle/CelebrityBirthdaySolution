<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require $myPath . 'includes/db_connect.php';
require $myPath . 'includes/functions.php';
require $myPath . 'includes/formkey.class.php';
require 'menufunctions.php';

sec_session_start();
$formKey = new formKey();

$currentPage = 'home';
$key = $formKey->outputKey();
$html = '';
if (login_check() == true) {


            echo '
        		<!doctype html>
        		<html>
        			<head>
                        <meta charset="UTF-8" />
                        <title>My Novel</title>
                        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        			    <link rel="stylesheet" href="/hindleware/css/style.css">
                        <link rel="icon" type="image/x-icon" href="/celebbirthday/favicon.ico"/>
                        <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
        			</head>
        			        
        			<body>';
            include $myPath . 'globNAV.php';
            echo '
    			        <div class="container" style="min-height:50vh;">

                            <div class="box" style="width:400px;margin:10px;">
                                <div class="btn bluebutton" style="padding:3px;width:100%;margin-top:15px;">
                                    <a href="' . $myPath . 'person/personsearch.php">
                                        <h3 style="color:white;">Search</h3>
                                    </a>
                                </div>
                                <div class="btn bluebutton" style="padding:3px;width:100%;margin-top:15px;">
                                    <a href="' . $myPath . 'deaths/deathsearchdates.php">
                                        <h3 style="color:white;">Deaths</h3>
                                    </a>
                                </div>                              
                            </div>

                        </div>                              ';
            $html .= '</body>
                 </html>';

    echo $html;
} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}

?>