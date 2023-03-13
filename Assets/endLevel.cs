using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{
    public CanvasGroup pic; 
    public GameObject player;

    void OnTriggerEnter2D(Collider2D thing)
    {
        Debug.Log("i run");
        if(thing.gameObject == player){
            pic.alpha=100;
        }
    }
}
