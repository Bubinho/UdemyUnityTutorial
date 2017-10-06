using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JumpPlayer : MonoBehaviour {

	[SerializeField]
	private AudioClip jumpClip;

	[SerializeField]
	private float jumpForce = 10f; 

	[SerializeField]
	private float forwardForce = 0f;
		
	private Rigidbody2D rb;
	private bool canJump;
	private Button jumpBtn;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		jumpBtn = GameObject.Find ("Jump Button").GetComponent<Button> ();

		jumpBtn.onClick.AddListener (() => Jump());
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (rb.velocity.y) == 0) {
			canJump = true;
		}
	}

	public void Jump(){
		if(canJump){
			canJump = false;

			//AudioSource.PlayClipAtPoint (jumpClip, transform.position);

			// if player is not in middle of the screen add forward movement
			if (transform.position.x < 0) {
				forwardForce = 2f;
			} else {
				forwardForce = 0f;
			}

			rb.velocity = new Vector2 (forwardForce, jumpForce);
			
		}
	}
}
