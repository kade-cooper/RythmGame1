using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Image healthBar;
    public float speed;
    public float jumpHeight;
    private Rigidbody2D r2d;
    private bool onGround;
    public GameObject swordPrefab;
    private Animator animator;
    public TextMeshProUGUI scoreTxt;
    private int score;
    public float health;
    public float maxhealth;
    public GameObject[] all;
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
            Instantiate(swordPrefab, this.transform.position + new Vector3(2f, 0.5f, 0f), Quaternion.identity);
            score-=100;
            scoreTxt.text = "Score: " + score.ToString();
        }
        else if(Input.GetButtonDown("Fire1") && onGround==true){
            animator.SetBool("Attacking", true);
            r2d.AddForce(new Vector3(0,jumpHeight,0));
            //Instantiate(swordPrefab, this.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
            //score-=100;
            scoreTxt.text = "Score: " + score.ToString();
        }
        else{
            animator.SetBool("Attacking", false);
        }
    }

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
        healthBar.fillAmount = health/maxhealth;
        SubScore();
        if(health==0){
            /*
            all = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach(GameObject obj in all){
                obj.SetActive(true);
            }
            
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                Debug.Log("i run");
                enemy.gameObject.SetActive(true);
            }
            */
            this.transform.position = new Vector2(-8,-3);
            score=0;
            scoreTxt.text = "Score: " + score.ToString();
            health=maxhealth;
            healthBar.fillAmount = health/maxhealth;
        }
    }
}
