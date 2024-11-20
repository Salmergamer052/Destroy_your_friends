using UnityEngine;

public class ApplyCharacterAppearance : MonoBehaviour
{
    public GameObject[] characterSprites;

    void Start()
    {
        int savedAppearanceIndex = CharacterState.Instance.GetAppearance();
        Debug.Log("Índice de apariencia aplicado en la escena del juego: " + savedAppearanceIndex); // Mensaje de depuración
        ChangeAppearance(savedAppearanceIndex);
    }

    void ChangeAppearance(int index)
    {
        foreach (GameObject sprite in characterSprites)
        {
            sprite.SetActive(false);
        }

        if (index >= 0 && index < characterSprites.Length)
        {
            characterSprites[index].SetActive(true);
            Debug.Log("Apariencia " + index + " activada."); // Mensaje de depuración
        }
        else
        {
            Debug.LogWarning("El índice de apariencia está fuera de rango");
        }
    }
}


