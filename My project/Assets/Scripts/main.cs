using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour{

    public static main Instance;
    public Web Web1;
    // Start is called before the first frame update
    void Start(){

        Instance = this;
        Web1 = GetComponent<Web>();
        
    }

}
