using UnityEngine;
using UnityEngine.UI;

public class CharacterAppearanceChanger : MonoBehaviour
{
    public SpriteRenderer characterRenderer; // Asigna aqu� el SpriteRenderer del personaje
    public Sprite[] appearances; // Lista de sprites para los diferentes aspectos del personaje
    private int currentIndex = 0;

    public void NextAppearance()
    {
        currentIndex = (currentIndex + 1) % appearances.Length;
        characterRenderer.sprite = appearances[currentIndex];
    }

    public void PreviousAppearance()
    {
        currentIndex = (currentIndex - 1 + appearances.Length) % appearances.Length;
        characterRenderer.sprite = appearances[currentIndex];
    }

    public void ChangeAppearance(int newIndex)
    {
        // Cambia la apariencia visual del personaje (esto ya deber�a estar en tu c�digo)
        // ...

        // Guarda el �ndice de la apariencia seleccionada en el estado del personaje
        CharacterState.Instance.SetAppearance(newIndex);
    }
}

