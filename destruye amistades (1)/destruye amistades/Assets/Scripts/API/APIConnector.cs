using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIConnector : MonoBehaviour
{
    private string apiUrl = "https://api.ejemplo.com/data"; // URL de tu API

    // Método para iniciar una solicitud GET
    public void FetchData()
    {
        StartCoroutine(GetData());
    }

    // Corrutina para hacer la solicitud GET
    private IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Respuesta de la API: " + request.downloadHandler.text);
        }
    }

    // Corrutina para hacer la solicitud POST
    public IEnumerator PostData(string jsonData)
    {
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Respuesta de la API: " + request.downloadHandler.text);
        }
    }
}




