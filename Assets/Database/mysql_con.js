const express = require('express');
const mysql = require('mysql');
const app = express();
const port = 9999;

const db = mysql.createConnection({
    host: '54.38.52.204',
    user: 'ubuntu',
    password: '27rhN@Vj^Exf*e',
    database: 'eoDB'
});

db.connect((err) => {
    if (err) throw err;
    console.log('Połączono z bazą danych');
});

app.get('/getdata', (req, res) => {
    let sql = 'SELECT username,password FROM Player LIMIT 1';
    db.query(sql, (err, result) => {
        if(err) throw err;
        console.log(result);
        res.send(result[0]);
    });
});

app.listen(port, () => {
    console.log(`Serwer działa na porcie ${port}`);
});