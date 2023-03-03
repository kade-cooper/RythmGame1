using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public int health;
    public int score;
    public GameObject electricExplosion;
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
        //check what kind of object
        if(other.gameObject.CompareTag("sword")){
            health-=1;
            if(health <= 0){
                GameObject player = GameObject.Find("Hat");
                player.SendMessage("AddScore",score+100);
                Instantiate(electricExplosion, this.transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);
            }
            //gameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);
        }
    }
}
