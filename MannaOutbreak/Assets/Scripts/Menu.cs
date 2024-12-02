using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{

    public void ButtonStart(){
        SceneManager.LoadScene(3);
    }

    public void ButtonLeaderboard(){
        SceneManager.LoadScene(2);
    }

    public void ButtonQuit(){
        Application.Quit();
    }
}
