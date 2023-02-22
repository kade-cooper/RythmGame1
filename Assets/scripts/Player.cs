using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    private Rigidbody2D r2d;
    private bool onGround;
    public GameObject swordPrefab;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        r2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position + new Vector3(speed*Time.deltaTime, 0f, 0f);
        this.transform.position = newPosition;
        if(Input.GetButtonDown("Jump") && onGround == true){
            animator.SetBool("Attacking", true);
            Instantiate(swordPrefab, this.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
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

    public void Respawn(){
        this.transform.position = new Vector2(-8,-3);
    }
}
