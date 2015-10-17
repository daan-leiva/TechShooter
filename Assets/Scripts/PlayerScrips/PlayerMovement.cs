using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    // public variables
    public float speed = 5;

	// private variables
	Rigidbody playerRigidBody;
	Vector3 movement;
	Animator anim;

	// set up variables
	void Awake() {
		playerRigidBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float h = Input.GetAxisRaw("Horizontal");

		Move (h);
	}

	void Move(float h) {
		// crate direction for movement vector
		Vector3 movement = new Vector3(h, 0f, 0f);

		// normalize so that motion depends on speed
		movement = movement.normalized*speed*Time.deltaTime;

		// move rigid body
		playerRigidBody.MovePosition(transform.position + movement);

		if(h != 0)
			anim.SetBool("IsWalking", true);
		else
			anim.SetBool("IsWalking", false);

	}
}
