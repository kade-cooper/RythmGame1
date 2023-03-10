using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public int health;
    public int score;
    public GameObject electricExplosion;
    public bool color;
    public GameObject bnw;
    public Vector3 offset;
    public float destroy = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, destroy);
    }

    public void OnTriggerEnter2D(Collider2D other){
        //GameObject gameUI = GameObject.Find("GameUI");
        //check what kind of object
        if(other.gameObject.CompareTag("sword")){
            health-=1;
            if(health <= 0){
                GameObject player = GameObject.Find("Hat");
                GameObject camera = GameObject.Find("Camera");
                player.SendMessage("AddScore",score+100);
                camera.SendMessage("beginShake");
                Instantiate(electricExplosion, this.transform.position + offset, Quaternion.identity);
                if(!color){bnw.SetActive(true);}
                else{bnw.SetActive(false);}
                Destroy(this.gameObject);
                //this.gameObject.SetActive(false);
            }
            //gameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);
        }
    }
}
