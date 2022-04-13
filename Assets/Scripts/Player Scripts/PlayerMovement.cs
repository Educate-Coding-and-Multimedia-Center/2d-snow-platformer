using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float speed = 5f;
	[SerializeField] float jumpPower = 5f;
	[SerializeField] float scalePlayer = 1.5f;
	[SerializeField] float edgeCamera = 7f;

	[SerializeField] Transform groundCheckPosition;
	[SerializeField] LayerMask colliderLayer;

	Rigidbody2D rb2d;
	Animator anim;

	bool isGrounded;
	bool jumped;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		transform.localScale = new Vector2 (scalePlayer, scalePlayer);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckGround ();
		PlayerJump ();
	}

	void FixedUpdate(){
		PlayerMove ();
	}

	void PlayerMove(){

		if (jumped) {
			PlayerMoveAdvance (speed / 2f);
		} else {
			PlayerMoveAdvance (speed);
		}

		//CheckEdgeLeftCamera ();

		anim.SetInteger ("Move", Mathf.Abs((int) rb2d.velocity.x));

	}

	void PlayerMoveAdvance(float speedPlayer){
		float move = Input.GetAxisRaw ("Horizontal");

		if (move > 0) {
			ChangeDirection (scalePlayer);
			//rb2d.velocity = new Vector2 (speedPlayer, rb2d.velocity.y);
			PlayerMovementSpeed(speedPlayer);
		} else if (move < 0) {
			ChangeDirection (-scalePlayer);
			//rb2d.velocity = new Vector2 (-speedPlayer, rb2d.velocity.y);
			PlayerMovementSpeed(-speedPlayer);
		} else {
			//rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
			PlayerMovementSpeed(0f);
		}
	}
		
	void PlayerMovementSpeed(float speed){
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}
		
	void CheckEdgeLeftCamera(){
		Vector3 cam = Camera.main.transform.position;

		if (transform.position.x < (cam.x - edgeCamera)) {
			//rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
			transform.position = new Vector2((cam.x - edgeCamera), transform.position.y);
		}
	}

	void ChangeDirection(float direction){
		Vector3 tempScale = transform.localScale;
		tempScale.x = direction;
		transform.localScale = tempScale;
	}

	void CheckGround(){
		isGrounded = Physics2D.Raycast (groundCheckPosition.position,
										Vector2.down, 0.1f, colliderLayer);
		if (isGrounded) {
			if (jumped) {
				jumped = false;
				anim.SetBool ("Jump", false);
			}
		}
	}

	void PlayerJump(){
		if (isGrounded) {
			if (Input.GetKey (KeyCode.Space)) {
				jumped = true;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpPower);
				anim.SetBool ("Jump", true);
			}
		}
	}
}
