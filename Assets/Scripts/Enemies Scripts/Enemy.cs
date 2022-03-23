using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] float speed = 5f;
	[SerializeField] int health = 1;

	[SerializeField] Transform leftCollision, rightCollision;
	[SerializeField] LayerMask colliderLayer;

	bool moveLeft;

	private Vector3 left_col_pos, right_col_pos;

	Rigidbody2D rb2d;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();

		left_col_pos = leftCollision.localPosition;
		right_col_pos = rightCollision.localPosition;
	}

	void Start () {
		moveLeft = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (moveLeft) {
			rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
		} else {
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		}

		CheckCollision ();
	}

	void CheckCollision(){
		RaycastHit2D leftHit = Physics2D.Raycast (leftCollision.position, Vector2.left, 0.1f, colliderLayer);
		RaycastHit2D rightHit = Physics2D.Raycast (rightCollision.position, Vector2.right, 0.1f, colliderLayer);

		if (leftHit) {			
			if (leftHit.collider.gameObject.tag == MyTagsLayers.PLAYER_TAG) {
				leftHit.collider.GetComponent<PlayerDamage> ().DealDamage ();
				rb2d.velocity = new Vector2 (30f, rb2d.velocity.y);
			} else {
				rb2d.velocity = new Vector2 (15f, rb2d.velocity.y);
				ChangeDirection ();
			}
		}

		if (rightHit) {
			if (rightHit.collider.gameObject.tag == MyTagsLayers.PLAYER_TAG) {
				rightHit.collider.GetComponent<PlayerDamage> ().DealDamage ();
				rb2d.velocity = new Vector2 (-30f, rb2d.velocity.y);
			} else {
				rb2d.velocity = new Vector2 (-15f, rb2d.velocity.y);
				ChangeDirection ();
			}
		}
	
	}

	void ChangeDirection(){
		moveLeft = !moveLeft;

		Vector3 tempScale = transform.localScale;

		if(moveLeft){
			tempScale.x = Mathf.Abs (tempScale.x);

			rightCollision.localPosition = right_col_pos;
			leftCollision.localPosition = left_col_pos;

		}

		if(!moveLeft){
			tempScale.x = -Mathf.Abs (tempScale.x);

			rightCollision.localPosition = left_col_pos;
			leftCollision.localPosition = right_col_pos;

		}

		transform.localScale = tempScale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == MyTagsLayers.SNOWBALL_TAG){
			CheckHealth ();
		}
	}

	public void CheckHealth(){
		health--;
		if(health < 1){
			Destroy (gameObject);
		}
	}
}
