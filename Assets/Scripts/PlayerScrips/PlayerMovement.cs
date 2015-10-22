using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    // public variables
    public float speed = 5;
	public float rotateSpeed = 600;
	public float jumpSpeed = 10;

	// private variables
	Rigidbody playerRigidBody;
	Vector3 movement;
	Animator anim;
	Quaternion rotation;

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

		if(Input.GetKey(KeyCode.Space) && playerRigidBody.velocity.y == 0)
		{
			anim.SetBool("Jump", true);
			//Jump ();
		}

		Rotate (h);
		Move (h);
	}

	void Jump() {
		transform.Translate(Vector3.up * 100 * Time.deltaTime, Space.World);
	}

	void Move(float h) {
		if(h != 0)
		{
			// crate direction for movement vector
			Vector3 movement = new Vector3(h, 0f, 0f);

			// normalize so that motion depends on speed
			movement = movement.normalized*speed*Time.deltaTime;

			// move rigid body
			playerRigidBody.MovePosition(transform.position + movement);

			// if non h and on floor
			if(playerRigidBody.velocity.y == 0)
				anim.SetBool("IsWalking", true);
		}
		else
			anim.SetBool("IsWalking", false);
	}


	void Rotate(float h) {
		if((h == 0 || transform.eulerAngles.y < 90 && h > 0) || (transform.eulerAngles.y > 270 && h < 0))
			return;

		transform.Rotate(-h/Mathf.Abs(h)*Vector3.up * rotateSpeed * Time.deltaTime);

	}
}
