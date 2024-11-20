using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public static CharacterState Instance { get; private set; } // Singleton para mantener una única instancia

    private int appearanceIndex = 0; // Índice de apariencia del personaje

    private void Awake()
    {
        // Verificar si ya existe una instancia de CharacterState
        if (Instance == null)
        {
            // Si no existe, asignar esta instancia y evitar que se destruya al cambiar de escena
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hacer que el objeto persista entre escenas
        }
        else
        {
            // Si ya existe una instancia, destruir este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }

    // Método para guardar el índice de apariencia
    public void SetAppearance(int index)
    {
        appearanceIndex = index;
    }

    // Método para obtener el índice de apariencia guardado
    public int GetAppearance()
    {
        return appearanceIndex;
    }
}



