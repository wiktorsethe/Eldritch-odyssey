const express = require('express');
const mysql = require('mysql');
const app = express();
const port = 9999;

const db = mysql.createConnection({
    host: '127.0.0.1',
    user: 'ubuntu',
    password: '27rhN@Vj^Exf*e',
    database: 'eoDB'
});

db.connect((err) => {
    if (err) throw err;
    console.log('Połączono z bazą danych');
});

$username = $_POST["username"];
$password = $_POST["password"];

app.get('/getdata', (req, res) => {
    let sql = 'SELECT password FROM Player WHERE username = $username';
    db.query(sql, (err, result) => {
        if(err) throw err;
        console.log(result);
        res.send(result);
    });
});

app.listen(port, () => {
    console.log(`Serwer działa na porcie ${port}`);
});