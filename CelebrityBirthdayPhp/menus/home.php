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
$bookid = 0;
if (login_check() == true) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        if (! isset($_POST['form_key']) || ! $formKey->validate()) {
            header('Location: ' . $myPath . 'index.php?error=1');
        } else {
            if (isset($_POST['bookid'])) {
                $bookid = sanitize_int($_POST['bookid']);
                $_SESSION['book_id'] = $bookid;
            }
        }
    } else {
        if (isset($_SESSION['book_id'])) {
            $bookid = $_SESSION['book_id'];
        } else {
            header('Location: ' . $myPath . 'books/selectbook.php');
        }
    }

    if ($bookid) {
        $book = getbook($bookid);
        if (isset($book)) {
            $_SESSION['book_name'] = $book['bookName'];
            $_SESSION['beatsheetid'] = $book['bookbeatsheetid'];
            echo '
        		<!doctype html>
        		<html>
        			<head>
                        <meta charset="UTF-8" />
                        <title>My Novel</title>
                        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        			    <link rel="stylesheet" href="' . $myPath . 'css/style.css">
                        <link rel="icon" type="image/x-icon" href="/mynovel/favicon.ico"/>
                        <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
        			</head>
        			        
        			<body>';
            include $myPath . 'globNAV.php';
            echo '
    			        <div class="container" style="min-height:50vh;">

                            <div class="box" style="width:400px;margin:10px;">
                                <div class="btn graybutton" style="padding:3px;width:100%;">
                                    <a href="' . $myPath . 'books/selectbook.php">
                                        <h3 style="color:white;">Books</h3>
                                    </a>
                                </div>
                                <div class="btn graybutton" style="padding:3px;margin-top:15px;width:100%;">
                                    <a href="' . $myPath . 'people/selectperson.php">
                                        <h3 style="color:white;">People</h3>
                                    </a>
                                </div>
                                <div class="btn graybutton" style="padding:3px;margin-top:15px;width:100%;">
                                    <a href="' . $myPath . 'places/selectplace.php">
                                        <h3 style="color:white;">Places</h3>
                                    </a>
                                </div>
                                <div class="btn graybutton" style="padding:3px;margin-top:15px;width:100%;">
                                    <a href="' . $myPath . 'events/selectevent.php">
                                        <h3 style="color:white;" >Events</h3>
                                    </a>
                                </div>
                                <div class="btn graybutton" style="padding:3px;margin-top:15px;width:100%;">
                                    <a href="' . $myPath . 'sources/selectsource.php">
                                        <h3 style="color:white;" >Sources</h3>
                                    </a>
                                </div>
                                <div class="btn graybutton" style="padding:3px;margin-top:15px;width:100%;">
                                    <a href="' . $myPath . 'menus/textmenu.php">
                                        <h3 style="color:white;" >Files</h3>
                                    </a>
                                </div>
                            </div>

                        </div>                              ';
            $html .= '</body>
                 </html>';
        } else {
            $html .= "<script>
							alert('There was a problem. Please check details and try again.');
							window.location.href='game-manage.php';
					  </script>";
        }
    } else {
        $html .= "<script>
						alert('There was a problem. Please check details and try again.');
						window.location.href='game-manage.php';
				  </script>";
    }
    echo $html;
} else {
    header('Location: ' . $myPath . 'index.php?error=1');
}

?>