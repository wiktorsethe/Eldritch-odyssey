<?php
session_start();
// Usunięcie wszystkich zmiennych sesji
session_unset();
// Zniszczenie sesji
session_destroy();
// Przekierowanie użytkownika na stronę logowania po wylogowaniu
header("Location: http://eldritchodyssey.com");
exit;
?>