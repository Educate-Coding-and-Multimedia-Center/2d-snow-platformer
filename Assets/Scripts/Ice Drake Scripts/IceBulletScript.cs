using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletScript : MonoBehaviour {

	[SerializeField] float speed = 5f;
	[SerializeField] GameObject explosion;

	PlayerDamage damagePlayer;

	Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();	
		damagePlayer = GameObject.FindGameObjectWithTag (MyTagsLayers.PLAYER_TAG).GetComponent<PlayerDamage> ();
	}
	

	void Update () {
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag (MyTagsLayers.PLAYER_TAG)) {
			damagePlayer.DealDamage ();
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	public float Speed {

		get {
			return speed;
		}
		set {
			speed = value;
		}

	}
}
