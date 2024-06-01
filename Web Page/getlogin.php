<?php
$conn = include('db_con.php');

$username = $_POST["username"];
$password = $_POST["password"];

$sql = "SELECT password FROM Player WHERE username = '".$username."' ";
$result = $conn->query($sql);

if($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        if($row['password'] == $password){
            echo $username."|".$password;

            $sessionToken = bin2hex(random_bytes(16));
            $insertQuery = "INSERT INTO active_sessions (user_id, session_token) VALUES (?, ?)";
            $stmt = $conn->prepare($insertQuery);
            $stmt->bind_param("is", $userId, $sessionToken);
            $stmt->execute();

        } else {
            echo "password incorrect";
        }
    }
}
?>