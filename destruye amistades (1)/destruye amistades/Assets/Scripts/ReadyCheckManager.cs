using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReadyCheckManager : MonoBehaviour
{
    public Toggle[] checks; // Lista de toggles
    public Button playButton; // Referencia al botón de Jugar

    void Start()
    {
        playButton.interactable = false; // Desactiva el botón al inicio

        // Suscribir el método CheckReadyStatus a cada Toggle
        foreach (var check in checks)
        {
            check.onValueChanged.AddListener(delegate { CheckReadyStatus(); });
        }
    }

    void CheckReadyStatus()
    {
        // Si todos los checks están activados, habilita el botón de Jugar
        playButton.interactable = checks.All(toggle => toggle.isOn);
    }
}
