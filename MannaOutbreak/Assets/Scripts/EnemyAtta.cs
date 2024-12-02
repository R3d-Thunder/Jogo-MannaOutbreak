using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtta : MonoBehaviour
{
    public GameOverScreen GameOverState;
    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player")){
            GlobalVar.BoxHave = false;
            GameOverState.Setup();
        }
    }
}
