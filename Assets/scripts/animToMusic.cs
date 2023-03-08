using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animToMusic : MonoBehaviour
{
	public AudioSource audioSource;
	public float updateStep = 0.01f;
	public int sampleDataLength = 1024;

	private float currentUpdateTime = 0f;

	public float clipLoudness;
	private float[] clipSampleData;

	public GameObject[] sprites;
	public bool animEnemies = false;
	public float sizeFactor = 0;

	public float minSize = 40;
	public float maxSize = 50;

	private void Awake()
	{
		clipSampleData = new float[sampleDataLength];
	}

	private void Update()
	{
		currentUpdateTime += Time.deltaTime;
		if (currentUpdateTime >= updateStep)
		{
			currentUpdateTime = 0f;
			audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); 
			clipLoudness = 0f;
			foreach (var sample in clipSampleData)
			{
				clipLoudness += Mathf.Abs(sample);
			}
			clipLoudness /= sampleDataLength; 

			clipLoudness *= sizeFactor;
			clipLoudness = Mathf.Clamp(clipLoudness, 0, maxSize);
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			if(animEnemies){
				foreach(GameObject enemy in enemies){
                //Debug.Log(clipLoudness);
                if(clipLoudness<minSize){
                    clipLoudness+=minSize;
                }
			    enemy.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
            }
			}
            foreach(GameObject sprite in sprites){
                //Debug.Log(clipLoudness);
                if(clipLoudness<minSize){
                    clipLoudness+=minSize;
                }
			    sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
            }
        }
	}
}