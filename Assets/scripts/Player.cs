using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    private Rigidbody2D r2d;
    private bool onGround;
    public GameObject swordPrefab;
    private Animator animator;
    public TextMeshProUGUI scoreTxt;
    private int score;
    public int health;
    public int maxhealth;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "Score: " + score.ToString();
        animator = GetComponent<Animator>();
        r2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position + new Vector3(speed*Time.deltaTime, 0f, 0f);
        this.transform.position = newPosition;
        if(Input.GetButtonDown("Jump")){
            animator.SetBool("Attacking", true);
            Instantiate(swordPrefab, this.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
            score-=100;
            scoreTxt.text = "Score: " + score.ToString();
        }
        else{
            animator.SetBool("Attacking", false);
        }
    }
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        } 
    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
*/
    public void AddScore(int addition){
        //Debug.Log("i run");
        score+=addition;
        scoreTxt.text = "Score: " + score.ToString();
    }

    public void SubScore(){
        //Debug.Log("i run");
        score-=300;
        scoreTxt.text = "Score: " + score.ToString();
    }

    public void Respawn(){
        health-=1;
        SubScore();
        if(health==0){
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                Debug.Log("i run");
                enemy.gameObject.SetActive(true);
            }
            this.transform.position = new Vector2(-8,-3);
            score=0;
            scoreTxt.text = "Score: " + score.ToString();
            health=maxhealth;
        }
    }
}
