using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float maxSpeed;

	bool isGrounded = false;

	Rigidbody2D myRB;
	Animator animator;

	bool facingRight;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
    public GameObject boss;
    public Transform spawnLoc;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = true;
	}

	// Update is called once per frame
	void Update() {
		if (isGrounded && Input.GetAxis ("Jump") > 0) {
			isGrounded = false;
			animator.SetBool ("isGrounded", isGrounded);
			myRB.AddForce (new Vector2(0, jumpHeight));
		}
	}

	void FixedUpdate () {
		// Check if player is grounded
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		animator.SetBool ("isGrounded", isGrounded);
		animator.SetFloat ("verticalSpeed", myRB.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("speed", Mathf.Abs(move));

		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

    public bool getFacingRight()
    {
        return facingRight;
    }


}
