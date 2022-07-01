<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>DeletePermit</title>
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
    <h1>Delete Permit</h1>
    <hr>

<table>
    <th>Request ID</th>
    <th>Submitted</th>
    <th>Completed</th>
    <th>Approval Status</th>
    <th>User</th>
    <th>Class</th>


    <?php
        include_once 'dbconfig.php';
    $crud->dataview("SELECT * FROM Permit_Requests");
    ?>
</table>
<form action="DeleteFunction.php" method="post">

    <label for="requestid">Request ID:</label><br>
    <input type="text" id="requestid" name="requestid" required><br>


    <input type="submit">
</form>
</div>
</body>
</html>