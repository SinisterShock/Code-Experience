
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
<a href="NewPermitAdmin.html">New Permit</a>
<a href="DeletePermit.php">Delete Permit</a>
<a href="ApprovalPermit.php">Approve a Permit</a>
<a href="login.php">Log Out</a>
</nav>
<div id="frontbar">
<h2>View Permits</h2>
<h3>Administrator</h3>

    <table>
        <th>Request ID</th>
        <th>Submitted</th>
        <th>Completed</th>
        <th>Approval Status</th>
        <th>User</th>
        <th>Class</th>


        <?php

        $crud->dataview("SELECT * FROM Permit_Requests");
        ?>
	</table>


</div>
</body>
</html>


