<!--
File: Lab06.php
Project: Lab 6
Creator: Tyler Burleson
Email: tburles6@stumail.northeaststate.edu
Course: CITC 1317 TR
-->

<?php
$nameErr = $emailErr = $websiteErr = $commentErr = "";
$name = $email = $website = $comment = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (empty($_POST["name"])) {
        $nameErr = "Name is required";
    }else {
        $name = $_POST["name"];
    }

    if (empty($_POST["email"])) {
        $emailErr = "Email is required";
    } else {
        $email = $_POST["email"];
    }

    if (empty($_POST["website"])) {
        $websiteErr = "Website is required";
    } else {
        $website = $_POST["website"];
    }

    if (empty($_POST["comment"])) {
        $commentErr = "Comment is required";
    } else {
        $comment = $_POST["comment"];
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Lab06</title>
</head>
<body>
<form action="<?php echo $_SERVER["PHP_SELF"]; ?>" method="post">

    Name: <input type="text" name="name">
    <span class="error">* <?php echo $nameErr;?></span><br>
    Email: <input type="text" name="email">
    <span class="error">* <?php echo $emailErr;?></span><br>
    Website: <input type="text" name="website">
    <span class="error">* <?php echo $websiteErr;?></span><br>
    Comments: <textarea name="comment" rows="5" cols="40"></textarea>
    <span class="error">* <?php echo $commentErr;?></span><br>

    <input type="submit">
</form>

<?php
echo "<br>";
echo $name;
echo "<br>";
echo $email;
echo "<br>";
echo $website;
echo "<br>";
echo $comment;
echo "<br>";

?>

</body>
</html>