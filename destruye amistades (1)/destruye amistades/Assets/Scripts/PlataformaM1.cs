using UnityEngine;

public class PlataformaM1 : MonoBehaviour
{
    public float moveDistance = 5f;  // Distancia a la que se moverá la plataforma
    public float moveSpeed = 2f;      // Velocidad de movimiento
    public float timeAtPosition = 3f; // Tiempo que se queda en cada posición

    private Vector3 startPosition;     // Posición inicial
    private Vector3 targetPosition;    // Posición objetivo
    private float timer;               // Temporizador
    private bool isMovingUp = true;    // Estado de movimiento
    private bool isWaiting = false;     // Estado de espera

    void Start()
    {
        startPosition = transform.position; // Guardamos la posición inicial
        targetPosition = startPosition + new Vector3(0, moveDistance, 0); // Calculamos la posición objetivo
    }

    void Update()
    {
        // Si no estamos esperando, movemos la plataforma
        if (!isWaiting)
        {
            MovePlatform();
        }

        // Incrementamos el temporizador si estamos en espera
        if (isWaiting)
        {
            timer += Time.deltaTime;

            // Verificamos si el tiempo de espera ha terminado
            if (timer >= timeAtPosition)
            {
                isWaiting = false; // Volvemos a mover la plataforma
                timer = 0f;        // Reiniciamos el temporizador
                isMovingUp = !isMovingUp; // Cambiamos la dirección
            }
        }
    }

    void MovePlatform()
    {
        Vector3 target = isMovingUp ? targetPosition : startPosition;
        float step = moveSpeed * Time.deltaTime;

        // Mover la plataforma
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Verificamos si hemos llegado a la posición objetivo
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isWaiting = true; // Iniciamos el periodo de espera
        }
    }
}

