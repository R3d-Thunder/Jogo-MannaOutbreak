using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxFlag : MonoBehaviour
{
    public GameObject Box;
    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player") && !GlobalVar.BoxHave){
            GlobalVar.BoxHave = true;
            Box.SetActive(false);
        }else if (GlobalVar.BoxHave){
            ShowError.ErrorMessage();
        }
    }
}
