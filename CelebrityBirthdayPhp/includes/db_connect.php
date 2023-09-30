<?php
require_once 'ret-config.php';
$mypdo = new PDO('sqlsrv:server=' . HOST . ';database=' . DATABASE . '', USER, PASSWORD);
?>