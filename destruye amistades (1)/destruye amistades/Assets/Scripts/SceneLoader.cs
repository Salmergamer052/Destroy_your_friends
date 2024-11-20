using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button yourButton; // Arrastra aqu� tu bot�n en el Inspector
    public string sceneToLoad; // Nombre de la escena a cargar

    void Start()
    {
        if (yourButton != null)
        {
            // Agrega un listener al bot�n para que cargue la escena cuando se haga clic
            yourButton.onClick.AddListener(LoadScene);
        }
    }

    void LoadScene()
    {
        // Carga la escena especificada
        SceneManager.LoadScene(sceneToLoad);
    }
}