<!--
File: Lab05.php
Project: Lab 5
Creator: Tyler Burleson
Email: tburles6@stumail.northeaststate.edu
Course: CITC 1317 TR
Creation Date: 9/28/21
-->
<?php
if($_SERVER["REQUEST_METHOD"] != "POST"){
    echo "The action should be set to POST";
}else{
    //Form was okay and using POST
    if(empty($_POST["name"])){
        echo "ERROR! name is required <br>\n";
    }else{
        //Name okay
        echo "Name= " . $_POST["name"] . "<br>\n";
    }

    if(empty($_POST["email"])){
        echo "ERROR! email is required <br>\n";
    }else{
        //email okay
        echo "Email= " . $_POST["email"] . "<br>\n";
    }

    if(empty($_POST["website"])){
        echo "ERROR! website is required <br>\n";
    }else{
        //website okay
        echo "Website= " . $_POST["website"] . "<br>\n";
    }

    if(empty($_POST["comment"])){
        echo "ERROR! comment is required <br>\n";
    }else{
        //comment okay
        echo "Comment= " . $_POST["comment"] . "<br>\n";
    }


}