using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReadyCheckManager : MonoBehaviour
{
    public Toggle[] checks; // Lista de toggles
    public Button playButton; // Referencia al bot�n de Jugar

    void Start()
    {
        playButton.interactable = false; // Desactiva el bot�n al inicio

        // Suscribir el m�todo CheckReadyStatus a cada Toggle
        foreach (var check in checks)
        {
            check.onValueChanged.AddListener(delegate { CheckReadyStatus(); });
        }
    }

    void CheckReadyStatus()
    {
        // Si todos los checks est�n activados, habilita el bot�n de Jugar
        playButton.interactable = checks.All(toggle => toggle.isOn);
    }
}
