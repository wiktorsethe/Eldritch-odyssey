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
    $new_username = $_POST['new_username'];
    $new_password = $_POST['new_password'];
    
    // Zabezpieczenie przed atakami typu SQL Injection
    $new_username = mysqli_real_escape_string($conn, $new_username);
    $new_password = mysqli_real_escape_string($conn, $new_password);
    
    // Zapytanie SQL dodające nowego użytkownika do bazy danych
    $query = "INSERT INTO Player (username, password) VALUES ('$new_username', '$new_password')";
    
    // Wykonanie zapytania
    if ($conn->query($query) === TRUE) {
        // Nowy użytkownik został dodany pomyślnie
        redirectTo('http://eldritchodyssey.com/game'); // Przekierowanie na stronę eldritchodyssey.com/game
    } else {
        // Błąd podczas dodawania nowego użytkownika
        echo "Błąd: " . $query . "<br>" . $conn->error;
    }
}
?>


<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eldritch Odyssey - Register</title>
</head>
<body>

    <h2>Formularz rejestracji</h2>

    <form action="" method="post">
        <label for="new_username">Nowa nazwa użytkownika:</label><br>
        <input type="text" id="new_username" name="new_username"><br><br>
        <label for="new_password">Nowe hasło:</label><br>
        <input type="password" id="new_password" name="new_password"><br><br>
        <input type="submit" value="Zarejestruj">
    </form>

</body>
</html>