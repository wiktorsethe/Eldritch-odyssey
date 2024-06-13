<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eldritch Odyssey - Main menu</title>
</head>
<body>

    <?php
        // Sprawdź, czy użytkownik jest zalogowany
        session_start();
        if(isset($_SESSION['username'])) {
            // Jeśli jest zalogowany, wyświetl dzień dobry i możliwość wylogowania
            echo "<p>Dzień dobry, {$_SESSION['username']}!</p>";
            echo "<p><a href='http://eldritchodyssey.com/game'>Wejdź do gry</a></p><br>";
            echo "<p><a href='http://eldritchodyssey.com/logout'>Wyloguj się</a></p>";
        } 
        else {
            // Jeśli nie jest zalogowany, wyświetl formularz logowania
            echo "<p><a href='http://eldritchodyssey.com/login'>Zaloguj się</a></p>";
        }
    ?>

    <p>Nie masz jeszcze konta? <a href="http://eldritchodyssey.com/register">Zarejestruj się</a></p>
</body>
</html>