using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour {

	private GameObject[] pipeHolders;
	private float distance = 2.5f;
	private float lastPipesX;
	private float pipeMin = -1.3f;
	private float pipeMax = 1.3f;


	void Awake () {
		pipeHolders = GameObject.FindGameObjectsWithTag ("PipeHolder");
		lastPipesX = pipeHolders [0].transform.position.x;

		for(int i = 1; i < pipeHolders.Length; i++){

			// check for last position
			if(lastPipesX < pipeHolders [i].transform.position.x){
				lastPipesX = pipeHolders [i].transform.position.x;
			}

			// do y variation stuff
			Vector3 temp =  pipeHolders [i].transform.position;
			temp.y = Random.Range (pipeMin, pipeMax);
			pipeHolders [i].transform.position = temp;



		}
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "PipeHolder") {
			Vector3 temp = target.transform.position;
			temp.x = lastPipesX + distance;
			temp.y = Random.Range (pipeMin, pipeMax);
			target.transform.position = temp;
			lastPipesX = temp.x;
		}
	
	}
}
