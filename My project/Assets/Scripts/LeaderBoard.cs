using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LeaderBoard : MonoBehaviour
{
    public DataBaseAccess DBAccess;
    public Text LBoard;
    public TimeSpan timePlayed;
    public int x = 1;

    void Start(){
        Invoke("DisplayLBoard",2f);
    }

    private async void DisplayLBoard(){
        var task = DBAccess.GetDataFromDB();
        var result = await task;
        var output = "";
        foreach (var score in result){
            if(x <=5 ){
                timePlayed = TimeSpan.FromSeconds(score.TimeClock);
                output += " " + x + "-> " + " Usuario: " + score.UserName + " Pontuacao: " + score.PointScore + " Tempo de Jogo: " + timePlayed.ToString("mm':'ss'.'ff") + "\n";
                x++;
            }
        }
        LBoard.text = output;
    }

    public void ButtonReturn(){
        SceneManager.LoadScene(0);
    }
}
