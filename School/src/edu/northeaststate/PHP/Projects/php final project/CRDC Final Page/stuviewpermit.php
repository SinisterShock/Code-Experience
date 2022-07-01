<html>
<head>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<nav id="header">
    <img src="https://www.northeaststate.edu/img/nescc_logo.png">
    <a href="student.php">Home</a>
    <a href="stuaddpermit2.php">New Permit</a>
    <a href="StudentViewForm.html">Current Requests</a>
    <a href="login.php">Log Out</a>
</nav>
<div id="frontbar">
    <h2>Your Requests</h2>
    <hr>

<?php

include_once 'dbconfig.php';

?>


    <table>
        <th>Request ID</th>
        <th>Submitted</th>
        <th>Completed</th>
        <th>Approval Status</th>
        <th>User</th>
        <th>Class</th>


        <?php
        $id = "0";
        if($id != NULL) {
            $id = $_POST["studentID"];
            $crud->dataview("select * from Permit_Requests Where user_id = " . $id);
        }


        ?>
    </table>

    <br>
    </div>
</div>
</body>
</html>


