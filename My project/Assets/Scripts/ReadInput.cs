using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public GameObject inputField;
    public int MenuInput;

    public void ReadInputNpc(){
        Int32.TryParse(inputField.GetComponent<Text>().text,out MenuInput);
        GlobalVar.TotalNPC = MenuInput;
    }
}
