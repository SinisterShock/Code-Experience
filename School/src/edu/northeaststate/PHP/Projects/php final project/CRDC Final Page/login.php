<?php
if($_SERVER['REQUEST_METHOD'] === "POST") {
    $hash = "";
    $select = "";
    $result = 0;
    function sanitize($data){
        $data = trim($data);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);

        return $data;
    }
    try {
        $DB_host = "localhost";
        $DB_user = "team_d";
        $DB_pass = "Password1";
        $DB_name = "TeamD";

        $username = "";
        $password = "";
        $pdo = "";

        $pdo = new PDO("mysql:host=$DB_host;dbname=$DB_name", $DB_user, $DB_pass);
        $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

        if (isset($_POST['fuser'])) {
            $username = sanitize($_POST['fuser']);
        }
        if (isset($_POST['fpass'])) {
            $password = sanitize($_POST['fpass']);

        }

        $select = $pdo->prepare("SELECT password FROM Users WHERE username = :username");
        $row = $select->fetch($select->execute(array(':username' => $username)));
        $stored_password = $row[0];
        if (password_verify($password, $stored_password)) {
            $password = $stored_password;
            echo "success";
        }

        $select = $pdo->prepare("SELECT * FROM Users WHERE username = ? AND password = ? AND title = 'Student'");
        $select->bindParam(1, $username, PDO::PARAM_STR);
        $select->bindParam(2, $password, PDO::PARAM_STR);

        $select->execute();

        $select2 = $pdo->prepare("SELECT * FROM Users WHERE username = ? AND password = ? AND title = 'Advisor'");
        $select2->bindParam(1, $username, PDO::PARAM_STR);
        $select2->bindParam(2, $password, PDO::PARAM_STR);

        $select2->execute();

        $select3 = $pdo->prepare("SELECT * FROM Users WHERE username = ? AND password = ? AND title = 'Administrator'");
        $select3->bindParam(1, $username, PDO::PARAM_STR);
        $select3->bindParam(2, $password, PDO::PARAM_STR);

        $select3->execute();

        $result1 = $select->rowCount();
        $result2 = $select2->rowCount();
        $result3 = $select3->rowCount();
        if ($result1 > 0) {
            header("location: student.php");
        } elseif($result2 > 0) {
            header("location: adviewpermit.php");
        } elseif($result3 > 0) {
            header("location: Adminviewpermit.php");
        }else{
            echo "*****Invalid login*****";
        }
    } catch (PDOException $e) {
        echo $e->getMessage();
    }
}
?>

<!DOCTYPE html>
<html>

<head>
    <link rel="stylesheet" href="styles.css">
</head>

<body>
<nav id="header">
    <img src="https://www.northeaststate.edu/img/nescc_logo.png">
    <h1>Northeast State Class Registrations</h1>
</nav>

    <div id="frontbar">
        <h2>Permit Request System</h2>
        <div id="login">
            <form action="login.php" method="Post">
                <h3>Login</h3>
                <label for="fuser">Username:</label><br>
                <input type="text" id="fuser" name="fuser"><br>
                <label for="fpass">Password:</label><br>
                <input type="text" id="fpass" name="fpass"><br><br>
                <input type="submit" name ="login" id="login" value="Sign in">
            </form>
        </div>
        <h3>Login Here</h3>
    </div>
</body>

</html>