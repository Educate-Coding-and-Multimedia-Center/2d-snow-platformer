using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletScript : MonoBehaviour {

	[SerializeField] float speed = 5f;
	[SerializeField] GameObject explosion;

	Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () {
		rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
	}
}
