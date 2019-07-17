using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NasAPITest : MonoBehaviour
{
   public void ButtonTest()
    {
        Debug.Log("Test !!");


    }

    void Start()
    {
        //StartCoroutine(GetText("http://192.168.50.9:32964/webapi/query.cgi?api=SYNO.API.Info&version=1&method=query&query=all"));

        //StartCoroutine(GetText("http://192.168.50.9:32964/webapi/entry.cgi?api=SYNO.FileStation.Info&version=2&method=get"));

        StartCoroutine(GetText("http://192.168.50.9:32964/webapi/FilStation/info.cgi?api=SYNO.FileStation.CreateFolder&method=create&version=1&folder_path=%2Ftest&name=%3A"));
    }

    IEnumerator GetText(string query)
    {
        //UnityWebRequest www = UnityWebRequest.Get("http://myds.com:port/webapi/query.cgi?api=SYNO.API.Info&version=1&method=query&quer y=all");
        //UnityWebRequest www = UnityWebRequest.Get("http://192.168.50.9:32964/webapi/query.cgi?api=SYNO.API.Info&version=1&method=query&query=all");
        UnityWebRequest www = UnityWebRequest.Get(query);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }


}
