<?php
/*
 * HINDLEWARE
 * Copyright (C) 2023 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require_once $myPath . 'includes/db_connect.php';

function updatedeath($personid, $description, $dod)
{
    global $mypdo;
    $deathdate = '';
    $dday = '';
    $dmonth = '';
    $dyear = '';
    $updated = 0;
    if (isset($dod) && $dod != '') {
        $deathdate = getdate(strtotime(str_replace('/', '-', $dod)));
        $dday = $deathdate['mday'];
        $dmonth = $deathdate['mon'];
        $dyear = $deathdate['year'];

        $sqlupdperson = "UPDATE person
        SET
        longdesc = :description,
        deathday = :dday,
        deathmonth = :dmonth,
        deathyear = :dyear
        WHERE Id = :personid";
        $stmtupdperson = $mypdo->prepare($sqlupdperson);
        $stmtupdperson->bindParam(':description', $description);
        $stmtupdperson->bindParam(':dday', $dday, PDO::PARAM_INT);
        $stmtupdperson->bindParam(':dmonth', $dmonth, PDO::PARAM_INT);
        $stmtupdperson->bindParam(':dyear', $dyear, PDO::PARAM_INT);
        $stmtupdperson->bindParam(':personid', $personid, PDO::PARAM_INT);
        $stmtupdperson->execute();
        $updated = $stmtupdperson->rowCount();
        
        $sqlreminder = "INSERT INTO Reminders
                            (personId,note)
                        VALUES
                            (:personid,'Death recorded. Edit WordPress and send tweet.')";
        $stmtreminder = $mypdo->prepare($sqlreminder);
        $stmtreminder->bindParam(':personid', $personid, PDO::PARAM_INT);
        $stmtreminder->execute();
    }
    return $updated;
}

function processdeath($action)
{
    global $mypdo;
    $html = '';
    if (isset($_POST['dod'], $_POST['description'])) {
        $personid = - 1;
        $description = $_POST['description'];
        $dod = '';
        if (isset($_POST['personid'])) {
            $personid = $_POST['personid'];
        }
        if (isset($_POST['dod'])) {
            $dod = $_POST['dod'];
        }

        if ($dod && $description) {
            $html = "";

               $updated = updatedeath($personid, $description, $dod);
                if ($updated == 1) {
                    $html .= "<script>
            						alert('Death recorded.');
            						window.location.href='../person/personsearch.php?u=death';
    					      </script>";
                } else {
                    $html .= "<script>
        						alert('Death NOT recorded.');
        						window.location.href='../person/personsearch.php?u=death';
    					      </script>";
                }

        } else {
            $html = "<script>
						alert('There was a problem. Please check details and try again.');
						window.location.href='../person/personsearch.php?u=death';
					  </script>";
        }
    }
    return $html;
}
?>