using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        //GameObject gameUI = GameObject.Find("GameUI");
        Debug.Log("i run");
        //check what kind of object
        if(other.gameObject.CompareTag("sword")){
            health-=1;
            if(health <= 0){
                Destroy(this.gameObject);
            }
            //gameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);
        }
    }
}
