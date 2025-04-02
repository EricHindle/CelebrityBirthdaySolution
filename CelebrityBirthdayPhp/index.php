<?PHP
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */

require 'includes/db_connect.php';
require 'includes/functions.php';
require 'includes/formkey.class.php';

sec_session_start();
$formKey = new formKey();

if (login_check() == true) {
    header('Location: logout.php');
} else {

    $html = '
    <!DOCTYPE html>
    <html lang="en">
          <head>
            <meta charset="UTF-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />
            <link rel="stylesheet" href="/hindleware/css/style.css" type="text/css">
            <link rel="icon" type="image/x-icon" href="/celebbirthday/favicon.ico"/>
            <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet" />
            <title>Celebrity Birthday</title>
          </head>
          <body>
          <div class="container">
              <div class="box">
                    <img src="img/CelebBirthdayLogo.png" alt="logo" class="logo" />
                    <form role="form" autocomplete="off" name="form1" method="post" action="process_login.php" class="form-group">
    ';
    $html .= $formKey->outputKey();
    $html .= '
                        <input type="text" class="form-field" name="username"  id="username" placeholder="username">
                        <input type="password" class="form-field" name="password" id="password" placeholder="password" autocomplete="off">
                        <button class="btn" type="submit">Sign in</button>
                    </form>
                    <br/>
                    <div class="dark-text">
                        <a href="struct/player/new-password.php">Forgotten Password</a>
                    </div>
                    <br/>
                    <div class="light-text">
                        <a href="struct/player/new-member.php" role="button">Create Account</a>
                    </div>
                </div>
                                ';
    if (isset($_GET['error'])) {
        $html .= '<div class="error-message">Your username and password combination is incorrect.</div>';
    }
    $html .= '            
                </div>
            </body>
        </html>
    ';
    echo $html;
}
?>
