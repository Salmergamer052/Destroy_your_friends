using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entró: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Es el jugador. Cargando GameOver...");
            SceneManager.LoadScene("GameOver");
        }
    }

}