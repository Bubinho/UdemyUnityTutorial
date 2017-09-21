using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bird : MonoBehaviour {

	public static Bird instance;

	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;
	private float bounceSpeed = 4f;

	private bool didFlap;

	public bool isAlive;

	private Button flapButton;

	void Awake(){
		if (instance == null) {
			instance = this;
		}

		isAlive = true;

		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flapButton.onClick.AddListener (() => FlapRecognized());

		CalcCamerasX ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isAlive) {
			MoveBirdForward ();

			if (didFlap) {
				didFlap = false; // we can only flap once per button press
				Flap();
			}

			RotateBird ();

		}
	}

	void MoveBirdForward(){
		Vector3 temp = transform.position;
		temp.x += forwardSpeed * Time.deltaTime;
		transform.position = temp;
	}

	void Flap(){
		rb.velocity = new Vector2 (0, bounceSpeed);
		anim.SetTrigger ("Flap");
	}

	void RotateBird(){
		if (rb.velocity.y >= 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} 
		else 
		{
			float angle = 0;
			angle = Mathf.Lerp (0, -90, -rb.velocity.y / 20);
			transform.rotation = Quaternion.Euler (0, 0, angle);

		}
	}

	public void FlapRecognized(){
		didFlap = true;

	}

	public float GetPositionX(){
		return transform.position.x;
	}

	void CalcCamerasX(){
		CameraScript.offsetX = Camera.main.transform.position.x - transform.position.x;
	}
}
