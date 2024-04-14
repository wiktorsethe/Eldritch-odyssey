<?php 
    session_start();
    include('db_con.php');

    $username = $_POST['username'];
    $password = $_POST['password'];

    $query = "SELECT * FROM Player WHERE username='$username' AND password='$password'";
    $result = mysqli_query($conn, $query);

    if(mysqli_num_rows($result) === 1){
        $row = mysqli_fetch_assoc($result);
        if($row['username'] === $username && $row['password'] === $password){
            echo "Login success!";
            $_SESSION['username'] = $row['username'];
            $_SESSION['id'] = $row['id'];
            header("Location: http://eldritchodyssey.com");
            exit();
        }
    }
    else {
        // Nieprawidłowe dane logowania
        echo "Nieprawidłowa nazwa użytkownika lub hasło!";
    }
?>