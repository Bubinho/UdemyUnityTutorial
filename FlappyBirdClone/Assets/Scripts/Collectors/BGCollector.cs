using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {

	private GameObject[] backgrounds;
	private GameObject[] grounds;

	private float lastBGX;
	private float lastGroundX;

	void Awake(){
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		grounds = GameObject.FindGameObjectsWithTag ("Ground");

		lastBGX = backgrounds [0].transform.position.x;
		lastGroundX = grounds [0].transform.position.x;

		for (int i = 1; i < backgrounds.Length; i++) {
			if(lastBGX < backgrounds[i].transform.position.x){
				lastBGX = backgrounds [i].transform.position.x;
			}
		}

		for (int i = 1; i < grounds.Length; i++) {
			if(lastGroundX < grounds[i].transform.position.x){
				lastGroundX = grounds[i].transform.position.x;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Background") {
			Vector3 temp = target.transform.position;
			temp.x = lastBGX + target.bounds.size.x; // letzte Posiiotn + hälfte des colliders
			target.transform.position = temp;
			lastBGX = target.transform.position.x;
		}

		else if (target.tag == "Ground") {
			Vector3 temp = target.transform.position;
			temp.x = lastGroundX + target.bounds.size.x;
			target.transform.position = temp;
			lastGroundX = target.transform.position.x;
		}


	}
}
