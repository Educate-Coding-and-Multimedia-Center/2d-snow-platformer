using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDrakeScript : MonoBehaviour {

	[SerializeField] float speed = 1f;

	HealthBarDrake healthBarDrake;

	public int maxHealth = 10;
	public int currentHealth;

	bool canDamage;

	Animator anim;
	Rigidbody2D rb2d;

	public Transform player;

	public bool isFlipped = false;


	void Awake(){
		anim = GetComponent<Animator> ();
		healthBarDrake = GameObject.Find ("Boss Health Bar").GetComponent<HealthBarDrake> ();
		rb2d = GetComponent<Rigidbody2D> ();
		canDamage = true;
		currentHealth = maxHealth;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//anim.Play ("Shoot");
		//anim.Play ("Idle");

	}
		
	IEnumerator WaitForDamage(){
		yield return new WaitForSeconds (0.5f);
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
					anim.SetBool("IsDead", true);
				}

				StartCoroutine (WaitForDamage ());
			}
		}
	}

	public void LookAtPlayer() {
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped) {
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped) {
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
