using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnToMusic : MonoBehaviour
{
	public AudioSource audioSource;
	public float updateStep = 0.01f;
	public int sampleDataLength = 1024;

	private float currentUpdateTime = 0f;

	public float clipLoudness;
	private float[] clipSampleData;

	public GameObject[] sprites;
	public float sizeFactor = 0;

	public float minSize = 40;
	public float maxSize = 50;
	public GameObject enemy;
	public float volumeToSpawn;

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
			Debug.Log(clipLoudness);
            if(clipLoudness>=volumeToSpawn){
                Instantiate(enemy,this.transform.position,Quaternion.Euler(0,-110,0));
            }
        }
	}

	public void changeAttributes(float[] updateVTS){
		//Debug.Log("I run");
		updateStep=updateVTS[0];
		volumeToSpawn=updateVTS[1];
	}
}