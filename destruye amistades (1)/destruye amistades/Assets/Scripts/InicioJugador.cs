using UnityEngine;
using Cinemachine;

public class InicioJugador : MonoBehaviour
{
    // Lista de prefabs de personajes, asignada desde el Inspector
    public GameObject[] personajes;

    // Referencia a la Cinemachine Virtual Camera, asignada desde el Inspector
    public CinemachineVirtualCamera cinemachineCam;

    private void Start()
    {
        // Verificar si la lista de personajes está vacía o no asignada
        if (personajes == null || personajes.Length == 0)
        {
            Debug.LogError("La lista de personajes está vacía o no está asignada.");
            return;
        }

        // Asegurarse de que PlayerPrefs tenga un valor asignado para "JugadorIndex"
        if (!PlayerPrefs.HasKey("JugadorIndex"))
        {
            // Si no existe el valor en PlayerPrefs, lo asignamos por defecto
            PlayerPrefs.SetInt("JugadorIndex", 0); // Ajustamos el índice a 0 como valor predeterminado
            PlayerPrefs.Save(); // Guardar los cambios en PlayerPrefs
            Debug.Log("JugadorIndex no estaba definido. Se asignó el valor predeterminado: 0");
        }

        // Depuración: Verificar cuántos personajes hay en la lista
        Debug.Log("Número de personajes asignados: " + personajes.Length);

        // Obtener el índice del personaje seleccionado desde PlayerPrefs
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex", 0);

        // Depuración: Mostrar el valor obtenido de PlayerPrefs
        Debug.Log("Índice obtenido de PlayerPrefs: " + indexJugador);

        // Asegurarnos de que el índice esté dentro del rango válido
        if (indexJugador < 0 || indexJugador >= personajes.Length)
        {
            Debug.LogWarning("Índice fuera de rango, ajustando a 0.");
            indexJugador = 0; // Ajuste de valor por defecto si está fuera de rango
        }

        // Verificar si ya existe un personaje en la escena con la etiqueta 'Player'
        if (GameObject.FindWithTag("Player") == null)
        {
            // Instanciar el personaje seleccionado en la posición actual
            GameObject personajeInstanciado = Instantiate(
                personajes[indexJugador],
                transform.position,
                Quaternion.identity
            );

            // Asignar el personaje instanciado como Follow y Look At en Cinemachine
            if (cinemachineCam != null)
            {
                cinemachineCam.Follow = personajeInstanciado.transform;
                cinemachineCam.LookAt = personajeInstanciado.transform;
            }
            else
            {
                Debug.LogError("Cinemachine Virtual Camera no asignada en el Inspector.");
            }
        }
        else
        {
            Debug.LogWarning("Ya existe un personaje en la escena con la etiqueta 'Player'.");
        }
    }
}
