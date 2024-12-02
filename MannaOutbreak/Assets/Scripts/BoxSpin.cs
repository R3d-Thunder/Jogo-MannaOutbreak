using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpin : MonoBehaviour
{
    void Start(){
        this.gameObject.SetActive(true);
    }
    void Update(){
        transform.Rotate(0f,25 * Time.deltaTime,0f, Space.Self);
    }
}
