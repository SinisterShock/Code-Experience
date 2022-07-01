<!--
File: Lab03-php.php
Project: Lab 3
Creator: Tyler Burleson
Email: tburles6@stumail.northeaststate.edu
Course: CITC 1317 TR
Creation Date: 9/21/21
-->
<?php
$lines = file('80s_vg_sales.csv');
$video_games = array();
?>

<?php
foreach ($lines as $line) {
    $video_games[] = explode(",", trim($line));


}
?>



<html>
<head>
    <title>Lab03</title>
</head>
<body>
<h2>80's Game Sales</h2>

<?php
echo "<table border ='1'>";
foreach ($video_games as $game){
    echo "<tr>";
    echo "<td>" . $game[0] . "</td>";
    echo "<td>" . $game[1] . "</td>";
    echo "<td>" . $game[2] . "</td>";
    echo "<td>" . $game[3] . "</td>";
    echo "<td>" . $game[4] . "</td>";
    echo "<td>" . $game[5] . "</td>";
    echo "</tr>\n";

}
echo "</table>";
$total = 0;
$firstIteration = true;
foreach($video_games as $game){
    if(!$firstIteration){
        $total += $game[5];
    }
    $firstIteration = false;
}
$total = $total * 100000;
echo "Total Estimated Global Sales: $total";

?>



</body>
</html>