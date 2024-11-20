using UnityEngine;

public class ApplyCharacterAppearance : MonoBehaviour
{
    public GameObject[] characterSprites;

    void Start()
    {
        int savedAppearanceIndex = CharacterState.Instance.GetAppearance();
        Debug.Log("�ndice de apariencia aplicado en la escena del juego: " + savedAppearanceIndex); // Mensaje de depuraci�n
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
            Debug.Log("Apariencia " + index + " activada."); // Mensaje de depuraci�n
        }
        else
        {
            Debug.LogWarning("El �ndice de apariencia est� fuera de rango");
        }
    }
}


