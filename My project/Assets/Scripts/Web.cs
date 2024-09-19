using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Web : MonoBehaviour {
    
    public string Link1 = "http://localhost/Unitybackend/GetDate.php";
    public string Link2 = "http://localhost/Unitybackend/ConnectDB.php";
    public string Link3 = "http://localhost/Unitybackend/LoginUser.php";
    public string Link4 = "http://localhost/Unitybackend/RegisterUser.php";
    public string Usuario = "";
    public string Senha = "";

void Start() {

        // A correct website page.
        StartCoroutine(GetDate(Link1));
        //StartCoroutine(Login(Usuario,Senha));
        //StartCoroutine(GetLogin(Usuario,Senha));
        StartCoroutine(GetUsers(Link2));
    
    }

    IEnumerator GetDate(string uri) {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result) {

                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;

            }

        }

    }

    IEnumerator GetUsers(string uri) {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result) {

                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;

            }

        }

    }

    public IEnumerator Login(string username, string password){
        
        WWWForm form = new WWWForm();
        form.AddField("LoginUser", username);
        form.AddField("LoginPass", password);

        using UnityWebRequest www = UnityWebRequest.Post(Link3, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success){

            Debug.LogError(www.error);

        }
        else{

            Debug.Log(www.downloadHandler.text);
        
        }
    
    }

    public IEnumerator GetLogin(string username, string password){
        
        WWWForm form = new WWWForm();
        form.AddField("LoginUser", username);
        form.AddField("LoginPass", password);

        using UnityWebRequest www = UnityWebRequest.Post(Link4, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success){

            Debug.LogError(www.error);

        }
        else{

            Debug.Log(www.downloadHandler.text);
        
        }
    
    }

}
