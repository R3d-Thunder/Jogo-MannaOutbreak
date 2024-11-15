using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    private int Test;
    public void ButtonStart(){
        SceneManager.LoadScene(1);
    }

    public void ButtonReturn(){
        SceneManager.LoadScene(0);
    }

}
