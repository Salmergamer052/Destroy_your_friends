using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RestAPI : MonoBehaviour
{
    private string URL = "http://localhost:8000/api/register";

    public Text levelText;
    public Text ExpText;

    public int index;
    void Start()
    {
        StartCoroutine(GetDatas());
    }

    IEnumerator GetDatas()
    {
        using (UnityWebRequest request= UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
                Debug.LogError(request.error);
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stats = SimpleJSON.JSONNode.Parse(json);

                levelText.text = "Level: " + stats[index]["level"];
                ExpText.text = "Exp: " + stats[index]["exp"];
            }
        }

    }
}

