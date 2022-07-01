<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Permit Record Check</title>
    <link rel="stylesheet" href="styles.css">
</head>

<body>
<nav id="header">
    <img src="https://www.northeaststate.edu/img/nescc_logo.png">
    <a href="adviewpermit.php">Home</a>
    <a href="NewPermitAdvisor.html">New Permit</a>
    <a href="login.php">Log Out</a>
</nav>
<div id="frontbar">
    <h1>Request Status</h1>
<?php

include_once 'dbconfig.php';

if(empty($_POST["userid"])) {
    echo "ERROR! Student ID required<br>\n";
}else{
    $userid = $_POST["userid"];
}

if(empty($_POST["classid"])) {
    echo "ERROR! Class ID required<br>\n";
}else{
    $classid = $_POST["classid"];
}
if($classid != NULL && $userid != NULL){
    $crud->create($userid,$classid);
    echo "<br>Record Created";
}else{
    echo "<br>Record can't be created";
}
?>
<div>
</body>
</html>
