using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{

    public void ButtonStart(){

        SceneManager.LoadScene(3);
    }

    public void ButtonCredit(){

        //a implentar
    }

    public void ButtonQuit(){

        Application.Quit();
    }
}
