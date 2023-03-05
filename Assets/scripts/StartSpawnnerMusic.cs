using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawnnerMusic : MonoBehaviour
{

    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D thing){
        if(thing.CompareTag("Player")){
            audioSource.Play();
        }
    }
}
