
<?php
$a = "-2.6 degrees";
$b = "a dinosaur";
$c = false;
$d = NULL;
$e = -8675309.99;  // shouldn't give away Jenny's number
$f = 0.0;
$g = "";
$h = 42;
$i = -21;
$j = array("the Shining", "Carrie","IT");
?>

<?php
function rowShort($var) {
    echo "<tr>";
    echo "<td>" .  gettype($var) . "</td>";
    echo "<td>" .  boolval($var) . "</td>";
    echo "<td>" .  intval($var) . "</td>";
    echo "<td>" .  floatval($var) . "</td>";
    echo "<td>" .  strval($var) . "</td>";
    echo "<td>";
    // var_dump($var);
    echo "</td>";
    echo "<td>";
    if (is_int($var)) { echo dechex($var);}
    echo "</td>";
    echo "</tr>";

}
?>



<html>
<head>
    <title>Lab02</title>
</head>
<body>
<table border ='1'>
    <thead>
    <tr>
        <th> Initial type </th>
        <th> Cast to bool </th>
        <th> Cast to int</th>
        <th> Cast to float</th>
        <th> Cast to string</th>
        <th> Variable info</th>
        <th> Int to Hex</th>
    </tr>
    </thead>

    <?php
    rowShort($a);
    rowShort($b);
    rowShort($c);
    rowShort($d);
    rowShort($e);
    rowShort($f);
    rowShort($g);
    rowShort($h);
    rowShort($i);
    rowShort($j);
    ?>
</table>
</body>
</html>
