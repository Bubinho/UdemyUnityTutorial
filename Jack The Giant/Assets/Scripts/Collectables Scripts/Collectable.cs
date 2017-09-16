using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	void OnEnabled(){
		Invoke ("DestroyCollectable", 6f);
	}

	void DestroyCollectable(){
		gameObject.SetActive (false);
	}
}
