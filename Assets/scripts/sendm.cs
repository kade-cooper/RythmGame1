using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendm : MonoBehaviour
{
    public GameObject spawnner;
    public float[] updateVTS;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D thing){
        //Debug.Log("for the love of god output");
        if(thing.CompareTag("Player")){
            //Debug.Log("i run too");
            spawnner.SendMessage("changeAttributes",updateVTS);
        }
    }
}
