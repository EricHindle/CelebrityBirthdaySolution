<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$myPath = '../';
require_once $myPath . 'includes/db_connect.php';

function getperson($personid){
    global $mypdo;
    $person = '';
    $personsql = "SELECT * FROM people WHERE personid = :id LIMIT 1";
    $personquery = $mypdo->prepare($personsql);
    $personquery->bindParam(':id', $personid, PDO::PARAM_INT);
    $personquery->execute();
    $personcount = $personquery->rowCount();
    if($personcount == 1){
        $person = $personquery->fetch(PDO::FETCH_ASSOC);
    }
    return $person;
}

function insertperson($forename, $surname, $sex, $age, $description, $birthname, $dob, $dod, $historical)
{
    global $mypdo;
    $name = $forename . ' ' . $surname;
    $sqladdperson = "INSERT INTO people 
        (name, forename, surname, sex, age, description, birthname, historical, date_of_birth, date_of_death) 
        VALUES 
        (:name, :forename, :surname, :sex, :age, :description, :birthname, :historical, :dob, :dod)";
    $stmtaddperson = $mypdo->prepare($sqladdperson);
    $stmtaddperson->bindParam(':name', $name);
    $stmtaddperson->bindParam(':forename', $forename);
    $stmtaddperson->bindParam(':surname', $surname);
    $stmtaddperson->bindParam(':sex', $sex);
    $stmtaddperson->bindParam(':age', $age, PDO::PARAM_INT);
    $stmtaddperson->bindParam(':description', $description);
    $stmtaddperson->bindParam(':birthname', $birthname);
    $stmtaddperson->bindParam(':dob', $dob);
    $stmtaddperson->bindParam(':dod', $dod);
    $stmtaddperson->bindParam(':historical', $historical, PDO::PARAM_INT);
    $stmtaddperson->execute();
    $added = $stmtaddperson->rowCount();
    return $added;
}

function updateperson($personid, $forename, $surname, $sex, $age, $description, $birthname, $dob, $dod, $historical, $deleted)
{
    global $mypdo;
    $name = $forename . ' ' . $surname;
    $sqlupdperson = "UPDATE people
        SET
        name = :name,
        surname = :surname,
        forename = :forename,
        description = :description,
        age = :age,
        sex = :sex,
        birthname = :birthname,
        historical = :historical,
        date_of_birth = :dob,
        date_of_death = :dod,
        persondeleted = :deleted
        WHERE personId = :personid";
    $stmtupdperson = $mypdo->prepare($sqlupdperson);
    $stmtupdperson->bindParam(':name', $name);
    $stmtupdperson->bindParam(':forename', $forename);
    $stmtupdperson->bindParam(':surname', $surname);
    $stmtupdperson->bindParam(':sex', $sex);
    $stmtupdperson->bindParam(':age', $age, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':description', $description);
    $stmtupdperson->bindParam(':birthname', $birthname);
    $stmtupdperson->bindParam(':dob', $dob);
    $stmtupdperson->bindParam(':dod', $dod);
    $stmtupdperson->bindParam(':historical', $historical, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':deleted', $deleted, PDO::PARAM_INT);
    $stmtupdperson->bindParam(':personid', $personid, PDO::PARAM_INT);
    $stmtupdperson->execute();
    $updated = $stmtupdperson->rowCount();
    return $updated;
}

function processperson($action)
{
    global $mypdo;
    $html = '';
    if (isset($_POST['forename'], $_POST['surname'], $_POST['sex'], $_POST['age'], $_POST['description'], $_SESSION['book_id'])) {
        $personid = -1;
        $bookid = $_SESSION['book_id'];
        $forename = $_POST['forename'];
        $surname = $_POST['surname'];
        $sex = $_POST['sex'];
        $age = sanitize_int($_POST['age']);
        $description = $_POST['description'];
        $birthname = '';
        $dob = '';
        $dod = '';
        $deleted = 0;
        $myhistorical = false;
        if (isset($_POST['birthname'])) {
            $birthname = $_POST['birthname'];
        }
        $historical = (isset($_POST['historical']) ? $_POST['historical'] : "false");
        $myhistorical = ($historical == "true" ? 1 : 0);
        
        $deleted = (isset($_POST['deleted']) ? $_POST['deleted'] : "false");
        $mydeleted = ($deleted == "true" ? 1 : 0);
        if (isset($_POST['personid'])) {
            $personid = $_POST['personid'];
        }
        if (isset($_POST['dob'])) {
            $dob = $_POST['dob'];
        }
        if (isset($_POST['dod'])) {
            $dod = $_POST['dod'];
        }

        if ($forename && $surname && $sex && $age && $description) {
            $html = "";

            if ($action == 'create') {

                $added = insertperson($forename, $surname, $sex, $age, $description, $birthname, $dob, $dod, $myhistorical);
                $name = $forename . ' ' . $surname;
                $result = '';
                if ($added == 1) {
                    $personid = $mypdo->lastInsertId();
                    $linkadded = addbookpersonlink($bookid, $personid);
                    if ($linkadded == 1) {
                        $result = ' and BookPerson';
                    }
                    $html .= "<script>
            						alert('" . $name . " : Person" . $result . " added.');
            						window.location.href='selectperson.php';
    					      </script>";
                } else {
                    $html .= "<script>
        						alert('" . $name . " : Person NOT added.');
        						window.location.href='selectperson.php';
    					      </script>";
                }
            } else {
                $updated = updateperson($personid, $forename, $surname, $sex, $age, $description, $birthname, $dob, $dod, $myhistorical, $mydeleted);
                $name = $forename . ' ' . $surname;
                $result = '';
                if ($updated == 1) {
                    $html .= "<script>
            						alert('" . $name . " : Person" . $result . " updated.');
            						window.location.href='selectperson.php';
    					      </script>";
                } else {
                    $html .= "<script>
        						alert('" . $name . " : Person NOT updated.');
        						window.location.href='selectperson.php';
    					      </script>";
                }
            }
        } else {
            $html = "<script>
						alert('There was a problem. Please check details and try again.');
						window.location.href='selectperson.php';
					  </script>";
        }
    }
    return $html;
}
?>