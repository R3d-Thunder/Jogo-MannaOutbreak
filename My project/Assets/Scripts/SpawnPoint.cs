using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Npc;
    public  int SpawnCount;
    void Start(){
        SpawnCount = GlobalVar.TotalNPC;
        Enemy = GameObject.Find("Enemy");
        Npc = GameObject.Find("Npc");
        SpawnDrop();
        TimerController.instance.BeginTimer();
    }

    void SpawnDrop(){
        int Z = 0;
        while (Z < SpawnCount){
            float xPos;
            float zPos;
            xPos= Random.Range(-7,247);
            zPos= Random.Range(-7,218);
            float X;
            X = Random.Range(1,3);
            if (X == 1){
                Instantiate(Enemy, new Vector3(xPos,0,zPos),Quaternion.identity);
            }else{
                Instantiate(Npc, new Vector3(xPos,0,zPos),Quaternion.identity);
            }
            Z++;
        }
    }
}
