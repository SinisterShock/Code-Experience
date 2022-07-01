
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
    <h2>Enter your ID</h2>
    <hr>
    <div id="login">
<?php
include_once 'dbconfig.php';
if(isset($_POST['btn-submit']))
{

    $userid = $_POST['stuid'];
    $classid = $_POST['course'];



    if($userid != null && $classid != NULL)
    {
        $crud->create($userid,$classid);
        echo "<h3>Inserted successfully</h3><br>";
    }
    else
    {
      echo "<h3>Failed to insert</h3><br>";
    }
}

?>

    <form action = "" method = "post">
        Student ID: <br>
        <input type = "text" id="stuid" name = "stuid" class='form-control' required><br>
        Course ID:<br>
        <input type = "text" id="course" name = "course" class='form-control' required><br><br>
        <input type = "submit" name="btn-submit">


    </form>
    </div>
</div>
</body>
</html>


