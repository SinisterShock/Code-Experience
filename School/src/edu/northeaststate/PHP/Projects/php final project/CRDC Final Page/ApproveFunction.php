<!doctype HTML>
<html>
<head>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<nav id="header">
    <img src="https://www.northeaststate.edu/img/nescc_logo.png">
    <a href="Adminviewpermit.php">Home</a>
    <a href="NewPermitAdmin.html">New Permit</a>
    <a href="DeletePermit.php">Delete Permit</a>
    <a href="ApprovalPermit.php">Approve a Permit</a>
    <a href="login.php">Log Out</a>
</nav>
<div id="frontbar">
    <h1>Approval Status</h1>
    <hr>
<?php
include_once 'dbconfig.php';

$requestid = $_POST["requestid"];
$approval = $_POST["approval"];

if($requestid != NULL && $approval != NULL){
    $crud->update($requestid, $approval);
    echo "Record Updated<br>\n";
}else{
    echo "ERROR! Try again in a few seconds<br>\n";
}
?>

</body>
</html>