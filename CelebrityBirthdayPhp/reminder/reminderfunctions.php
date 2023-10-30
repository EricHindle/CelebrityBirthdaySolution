<?php
/*
 * HINDLEWARE
 * Copyright (C) 2023 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require_once $myPath . 'includes/db_connect.php';

function insertreminder($personid, $note)
{
    global $mypdo;
    $sqladdreminder = "INSERT INTO reminders
        (personid, note)
        VALUES
        (:personid, :note)";
    $stmtaddreminder = $mypdo->prepare($sqladdreminder);
    $stmtaddreminder->bindParam(':personid', $personid, PDO::PARAM_INT);
    $stmtaddreminder->bindParam(':note', $note);
   
    $stmtaddreminder->execute();
    $added = $stmtaddreminder->rowCount();
    return $added;
}

?>