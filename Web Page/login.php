<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Logowanie</title>
</head>
<body>
    <header>
        <h1>Zaloguj się</h1>
    </header>
    <main>
        <form action="login_process.php" method="post">
            <label for="username">Nazwa użytkownika:</label><br>
            <input type="text" id="username" name="username" required><br>
            <label for="password">Hasło:</label><br>
            <input type="password" id="password" name="password" required><br><br>
            <input type="submit" value="Zaloguj się">
        </form>
    </main>
    <footer>
        <p>Strona stworzona przez [twoją nazwę lub pseudonim]</p>
    </footer>
</body>
</html>