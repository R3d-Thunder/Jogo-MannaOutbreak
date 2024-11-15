using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ShowError : MonoBehaviour
{
    private static float ShowTimmer = 0f;
    public static GameObject Message;
    public GameObject x;

    private void Start(){
        Message = x;
    }

    private void Update(){
        ShowTimmer -= Time.deltaTime;
        if (ShowTimmer <= 0f){
            this.gameObject.SetActive(false);
        }
    }

    public void SetThisActive(){
        this.gameObject.SetActive(true);
    }

    public static void ErrorMessage()
    {
        Message.SetActive(true);
        ShowTimmer = 2f;
    }
}
