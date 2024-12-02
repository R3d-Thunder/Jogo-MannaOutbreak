using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrop : MonoBehaviour
{
    public GameObject Message;
    private float ShowTimmer = 0f;
    private int BoxDropCount;
    public GameOverScreen GameOverState;

    private void Start(){
        BoxDropCount = 0;
    }

    private void Update(){
        ShowTimmer -= Time.deltaTime;
        if (ShowTimmer <= 0f){
            Message.SetActive(false);
        }
    }

    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player") && GlobalVar.BoxHave){
            GoodMessage();
            GlobalVar.BoxHave = false;
            GlobalVar.PointScore += 5000;
            BoxDropCount ++;
        }

        if(BoxDropCount >= 4){
            GlobalVar.BoxHave = false;
            GameOverState.Setup();
        }
    }

    public void GoodMessage()
    {
        Message.SetActive(true);
        ShowTimmer = 2f;
    }
}
