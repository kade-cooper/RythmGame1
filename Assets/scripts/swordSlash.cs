using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSlash : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position + new Vector3(speed*Time.deltaTime, 0f, 0f);
        this.transform.position = newPosition;
    }
    
}
