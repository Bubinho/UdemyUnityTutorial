using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;
	private Vector3 startScale;



	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		startScale = transform.localScale;
	}
	// Use this for initialization
	void Start () {
		
	}


	void FixedUpdate () {
		PlayerMoveKeyBoard ();
	}


	void PlayerMoveKeyBoard(){
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			if (vel < maxVelocity) {// to avoid speeding up faster and faaster and faster ....
				forceX = speed;
			}
			Vector3 temp = transform.localScale;
			temp.x = startScale.x; 
			transform.localScale = temp; // set face of player to right
			anim.SetBool ("Walk", true); // start walking anim

		} 
		else if (h < 0) {
			if (vel < maxVelocity) {
				forceX = -speed;
			}
			Vector3 temp = transform.localScale;
			temp.x = -startScale.x; 
			transform.localScale = temp; // set face of player to right
			anim.SetBool ("Walk", true); // start walking anim
		}
		else{
			anim.SetBool ("Walk", false);// stop walking anim
		}

		myBody.AddForce (new Vector2(forceX, 0));
	}
}
