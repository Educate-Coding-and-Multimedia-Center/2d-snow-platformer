using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDrakeScript : MonoBehaviour {

	[SerializeField] float speed = 1f;

	HealthBarDrake healthBarDrake;

	public int maxHealth = 10;
	public int currentHealth;

	bool moveLeft, canDamage;

	Animator anim;
	Rigidbody2D rb2d;

	void Awake(){
		anim = GameObject.Find ("Ice Drake").GetComponent<Animator> ();
		healthBarDrake = GameObject.Find ("Boss Health Bar").GetComponent<HealthBarDrake> ();
		rb2d = GetComponent<Rigidbody2D> ();
		canDamage = true;
		currentHealth = maxHealth;
	}

	void Start () {
		moveLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
		//anim.Play ("Shoot");
		//anim.Play ("Idle");
		BossWalk();

	}
		
	public void BossWalk(){
		anim.Play ("Walk");

		Vector2 temp = transform.position;

		for (int i = 0; i < 10; i++) {
			if (moveLeft) {
				temp.x -= speed * Time.deltaTime;
				//rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
			} else {
				temp.x += speed * Time.deltaTime;
				//rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
			}

			transform.position = temp;
		}

		moveLeft = !moveLeft;

	}

	IEnumerator WaitForDamage(){
		yield return new WaitForSeconds (1f);
		canDamage = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == MyTagsLayers.SNOWBALL_TAG){
			if (canDamage) {
				currentHealth--;
				healthBarDrake.SetHealth (currentHealth);
				canDamage = false;

				if (currentHealth <= 0) {
					//gameObject.SetActive (false);
					anim.Play ("Dead");
				}

				StartCoroutine (WaitForDamage ());
			}
		}
	}
}
