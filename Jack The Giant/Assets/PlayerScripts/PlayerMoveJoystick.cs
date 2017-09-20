using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;
	private Vector3 startScale;

	private bool moveLeft, moveRight;

	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		startScale = transform.localScale;
	}

	// Use this for initialization
	void Start () {
		
	}
	

	void FixedUpdate () {
		if (moveLeft) {
			MoveLeft ();
		}

		if(moveRight){
			MoveRight();
		}
	}

	public void SetMoveLeft(bool moveLeft){
		this.moveLeft = moveLeft;
		this.moveRight = !moveLeft;
	}

	public void StopMoving() {
		moveLeft = moveRight = false;
		anim.SetBool ("Walk", false);
	}


	void MoveLeft(){
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		if (vel < maxVelocity) {
			forceX = -speed;
		}
		Vector3 temp = transform.localScale;
		temp.x = -startScale.x; 
		transform.localScale = temp; // set face of player to right
		anim.SetBool ("Walk", true); // start walking anim
		myBody.AddForce (new Vector2(forceX, 0));
	}

	void MoveRight(){
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		if (vel < maxVelocity) {
			forceX = speed;
		}
		Vector3 temp = transform.localScale;
		temp.x = startScale.x; 
		transform.localScale = temp; // set face of player to right
		anim.SetBool ("Walk", true); // start walking anim
		myBody.AddForce (new Vector2(forceX, 0));
	}
}
