<html>
<head>
<link rel="stylesheet" href="styles.css">
</head>
<body>
<?php

include_once 'dbconfig.php';

?>
<nav id="header">
    <img src="https://www.northeaststate.edu/img/nescc_logo.png">
    <a href="adviewpermit.php">Home</a>
    <a href="NewPermitAdvisor.html">New Permit</a>
    <a href="login.php">Log Out</a>
</nav>
<div id="frontbar">
<h2>View permits</h2>
<h3>Advisor</h3>

    <table>
        <th>Request ID</th>
        <th>Submitted</th>
        <th>Completed</th>
        <th>Approval Status</th>
        <th>User</th>
        <th>Class</th>


        <?php
        $crud->dataview("SELECT * FROM Permit_Requests");
        ?></table>


</div>
</body>
</html>


