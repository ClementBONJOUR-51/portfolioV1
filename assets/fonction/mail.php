<?php
$subject = $_GET["subject"];
$email = $_GET["email"];
$message = $_GET["message"];

ini_set( 'display_errors', 1);
error_reporting( E_ALL );
$to ="admin@bonjourclement51.go.yo.fr";
$headers = "From:" . $email;
mail($to,$subject,$message, $headers);
echo ("ok");
header("Location: https://bonjourclement51.go.yo.fr/");
?>