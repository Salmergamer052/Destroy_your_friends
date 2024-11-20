using UnityEngine;
using UnityEngine.Networking;
using TMPro; // Para mostrar el nombre si usas TextMeshPro
using System.Collections; // Importa el espacio de nombres necesario para IEnumerator

public class UserNameFetcher : MonoBehaviour
{
    public TextMeshProUGUI userNameText; // Arrastra el objeto Text aquí
    private string apiUrl = "http://localhost/api/routes/get_user_name.php"; // Cambia al URL de tu API

    void Start()
    {
        StartCoroutine(FetchUserName());
    }

    IEnumerator FetchUserName()
    {
        string url = $"{apiUrl}?id=15";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error: {request.error}");
        }
        else
        {
            // Parsear el JSON recibido
            string json = request.downloadHandler.text;
            UserNameResponse response = JsonUtility.FromJson<UserNameResponse>(json);

            if (!string.IsNullOrEmpty(response.name))
            {
                // Mostrar el nombre en el texto
                userNameText.text = response.name;
            }
            else
            {
                Debug.LogError("Error al obtener el nombre: " + json);
            }
        }
    }
}

[System.Serializable]
public class UserNameResponse
{
    public string name;
    public string error;
}

