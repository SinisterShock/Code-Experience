<!--
File: Lab07.php
Project: Lab 7
Creator: Tyler Burleson
Email: tburles6@stumail.northeaststate.edu
Course: CITC 1317 TR
-->
<?php
function sanitize($data){
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlspecialchars($data);
    return $data;
}
?>
<?php
$nameErr = $emailErr = $websiteErr = $commentErr = "";
$name = $email = $website = $comment = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (empty($_POST["name"])) {
        $nameErr = "Name is required";
    }else {
        $name = sanitize($_POST["name"]);

        if (!preg_match("/^[a-zA-Z-' ]*$/",$name)) {
            $nameErr = "Only letters and white space allowed";
        }
    }

    if (empty($_POST["email"])) {
        $emailErr = "Email is required";
    } else {
        $email = sanitize($_POST["email"]);

        if(!filter_var($email, FILTER_VALIDATE_EMAIL)){
            $emailErr = "Invalid email format";
        }
    }

    if (empty($_POST["website"])) {
        $websiteErr = "Website is required";
    } else {
        $website = sanitize($_POST["website"]);

        if (!preg_match("/\b(?:(?:https?|ftp):\/\/|www\.)[-a-z0-9+&@#\/%?=~_|!:,.;]*[-a-z0-9+&@#\/%=~_|]/i",$website)){
            $websiteErr = "Invalid URL";
        }
    }

    if (empty($_POST["comment"])) {
        $commentErr = "Comment is required";
    } else {
        $comment = sanitize($_POST["comment"]);
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Lab07</title>
</head>
<body>
<form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">

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