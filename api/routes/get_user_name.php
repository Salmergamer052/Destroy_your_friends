<?php
// Conexión a la base de datos
$servername = "localhost";
$username = "root"; // Cambia si tienes un usuario distinto
$password = ""; // Cambia si tienes contraseña
$dbname = "laravel"; // Cambia al nombre de tu base de datos

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Conexión fallida: " . $conn->connect_error);
}

$id_usuario = $_GET['id']; // ID del usuario recibido desde Unity

$sql = "SELECT name FROM users WHERE id = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("i", $id_usuario);
$stmt->execute();
$result = $stmt->get_result();

if ($row = $result->fetch_assoc()) {
    echo json_encode(['name' => $row['name']]);
} else {
    echo json_encode(['error' => 'Usuario no encontrado']);
}

$stmt->close();
$conn->close();
