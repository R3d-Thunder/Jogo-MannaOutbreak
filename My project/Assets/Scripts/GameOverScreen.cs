using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AstronautPlayer;

public class GameOverScreen : MonoBehaviour
{
    public GameObject PointText;
    public GameObject TimeText;
    public SpawnPoint TimeFunc;
    public GameObject NameInput;
    private int X;
    public AstronautPlayerCont PlayerController;
    public DataBaseAccess DBAccess;

    public void Setup(){
        this.gameObject.SetActive(true);
        TimeFunc.EndTimer();
        X = 1800 - (int) TimeFunc.timePlaying.TotalSeconds;
        GlobalVar.PointScore = (X + GlobalVar.TotalNPC + GlobalVar.PointScore) / (2 - (GlobalVar.InfectionRate/100));
        PointText.GetComponent<Text>().text = "Pontuacao: " + GlobalVar.PointScore.ToString();
        TimeText.GetComponent<Text>().text = TimeFunc.timeCounter.text;
        PlayerController.MoveMake(false);
    }

    public void DBNameInput(){
        GlobalVar.Name = NameInput.GetComponent<Text>().text;
    }
    
    public void ButtonRetry(){
        SceneManager.LoadScene(1);
        DBAccess.SaveDataToDB(GlobalVar.Name, GlobalVar.PointScore, TimeFunc.timePlaying.TotalSeconds);
    }

    public void Remake(){
        SceneManager.LoadScene(3);
        DBAccess.SaveDataToDB(GlobalVar.Name, GlobalVar.PointScore, TimeFunc.timePlaying.TotalSeconds);
    }
    
    public void ButtonMainMenu(){
        SceneManager.LoadScene(0);
        DBAccess.SaveDataToDB(GlobalVar.Name, GlobalVar.PointScore, TimeFunc.timePlaying.TotalSeconds);
    }
}
