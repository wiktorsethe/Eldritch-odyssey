<?php
include('db_con.php');

$playerId = $_POST["userid"];
$sql = "SELECT * FROM Character WHERE Player_id='".$playerId."' ";
$result = $conn->query($sql);
if($result->num_rows > 0){
    while($row = $result->fetch_assoc()){
        echo $row["character_name"]."|".$row["gender"]."\n";
    }
}