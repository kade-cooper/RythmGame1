using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 0.5f;

    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x + offset.x, offset.y, offset.z); 
        if(start){
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking(){
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;
        while(elapsedTime<duration){
            elapsedTime+=Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            Vector3 pos = Random.insideUnitSphere * strength;
            transform.position = new Vector3(player.position.x + offset.x + pos.x, offset.y + pos.y, offset.z + pos.z);
            yield return null;
        }
        transform.position = new Vector3 (player.position.x + offset.x, offset.y, offset.z);
    }

    public void beginShake(){
        start=true;
    }
}
