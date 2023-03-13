using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPlayer : MonoBehaviour
{
    public GameObject bnw;
    public bool color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            this.gameObject.SetActive(false);
            other.gameObject.SendMessage("Respawn");
            if(!color){bnw.SetActive(true);}
                else{bnw.SetActive(false);}
            //Destroy(other.gameObject);
        }
    }

}
