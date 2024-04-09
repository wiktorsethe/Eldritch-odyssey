<?php
// Załączenie pliku db_con.php
include('db_con.php');

// Funkcja do przekierowania na inną stronę
function redirectTo($url) {
    header('Location: ' . $url);
    exit();
}

// Sprawdzenie, czy dane zostały przesłane z formularza
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Przechwycenie danych z formularza
    $username = $_POST['username'];
    $password = $_POST['password'];
    
    // Zabezpieczenie przed atakami typu SQL Injection
    $username = mysqli_real_escape_string($conn, $username);
    $password = mysqli_real_escape_string($conn, $password);
    
    // Zapytanie SQL sprawdzające istnienie użytkownika w bazie danych
    $query = "SELECT * FROM Player WHERE username='$username' AND password='$password'";
    $result = $conn->query($query);
    
    // Sprawdzenie, czy wynik zapytania zawiera jakieś wiersze
    if ($result->num_rows > 0) {
        // Użytkownik istnieje, zalogowano pomyślnie
        redirectTo('http://eldritchodyssey.com/game'); // Przekierowanie na stronę eldritchodyssey.com/game
    } else {
        // Nieprawidłowe dane logowania
        echo "Nieprawidłowa nazwa użytkownika lub hasło!";
    }
}
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eldritch Odyssey - Main menu</title>
</head>
<body>
    <h2>Formularz logowania</h2>

    <form action="" method="post">
        <label for="username">Nazwa użytkownika:</label><br>
        <input type="text" id="username" name="username"><br><br>
        <label for="password">Hasło:</label><br>
        <input type="password" id="password" name="password"><br><br>
        <input type="submit" value="Zaloguj">
    </form>

    <p>Nie masz jeszcze konta? <a href="http://eldritchodyssey.com/register">Zarejestruj się</a></p>

</body>
</html>