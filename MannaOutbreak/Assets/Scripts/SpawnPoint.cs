using System;
using System.Collections;
using System.Collections.Generic;
using AstronautPlayer;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnPoint : MonoBehaviour{
    public Text timeCounter;
    public TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;
    public GameObject Enemy;
    public GameObject Npc;
    public  int SpawnCount;
    public AstronautPlayerCont PlayerController;

    void Start(){
        GlobalVar.PointScore = 0;
        PlayerController.MoveMake(true);
        SpawnCount = GlobalVar.TotalNPC;
        Enemy = GameObject.Find("Enemy");
        Npc = GameObject.Find("Npc");
        timeCounter.text = "Tempo: 00:00.00";
        timerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
        Random.InitState((int)DateTime.Now.Ticks);
        SpawnDrop();   
    }
    void SpawnDrop(){
        int Z = 0;
        while (Z < SpawnCount){
            float xPos;
            float zPos;
            xPos= UnityEngine.Random.Range(14f,246f);//246
            zPos= UnityEngine.Random.Range(14f,217f);//217
            float X;
            X= UnityEngine.Random.Range(1,101);
            if (X < GlobalVar.InfectionRate){
                Instantiate(Enemy, new Vector3(xPos,0,zPos),Quaternion.identity);
            }else{
                Instantiate(Npc, new Vector3(xPos,0,zPos),Quaternion.identity);
            }
            Z++;
        }
    }
    public void EndTimer()
    {
        timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Tempo: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
