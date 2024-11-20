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
        // Verificar si la lista de personajes est� vac�a o no asignada
        if (personajes == null || personajes.Length == 0)
        {
            Debug.LogError("La lista de personajes est� vac�a o no est� asignada.");
            return;
        }

        // Asegurarse de que PlayerPrefs tenga un valor asignado para "JugadorIndex"
        if (!PlayerPrefs.HasKey("JugadorIndex"))
        {
            // Si no existe el valor en PlayerPrefs, lo asignamos por defecto
            PlayerPrefs.SetInt("JugadorIndex", 0); // Ajustamos el �ndice a 0 como valor predeterminado
            PlayerPrefs.Save(); // Guardar los cambios en PlayerPrefs
            Debug.Log("JugadorIndex no estaba definido. Se asign� el valor predeterminado: 0");
        }

        // Depuraci�n: Verificar cu�ntos personajes hay en la lista
        Debug.Log("N�mero de personajes asignados: " + personajes.Length);

        // Obtener el �ndice del personaje seleccionado desde PlayerPrefs
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex", 0);

        // Depuraci�n: Mostrar el valor obtenido de PlayerPrefs
        Debug.Log("�ndice obtenido de PlayerPrefs: " + indexJugador);

        // Asegurarnos de que el �ndice est� dentro del rango v�lido
        if (indexJugador < 0 || indexJugador >= personajes.Length)
        {
            Debug.LogWarning("�ndice fuera de rango, ajustando a 0.");
            indexJugador = 0; // Ajuste de valor por defecto si est� fuera de rango
        }

        // Verificar si ya existe un personaje en la escena con la etiqueta 'Player'
        if (GameObject.FindWithTag("Player") == null)
        {
            // Instanciar el personaje seleccionado en la posici�n actual
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
