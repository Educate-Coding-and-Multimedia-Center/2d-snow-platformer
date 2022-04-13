using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBullet : MonoBehaviour {

	[SerializeField] float speed = 5f;
	[SerializeField] float timeDestroy = 3f;
	[SerializeField] ParticleSystem explosion;

	void Start () {
		Invoke ("SelfDestruct", timeDestroy);
	}
	
	void Update () {
		Move ();
	}

	public void Move(){
		Vector3 temp = transform.position;
		temp.x += speed * Time.deltaTime;
		transform.position = temp;
	}

	void SelfDestruct(){
		Destroy (gameObject);
	}

	public float Speed {

		get {
			return speed;
		}
		set {
			speed = value;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == MyTagsLayers.ENEMY_TAG || other.tag == MyTagsLayers.BOSS_TAG){
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
		if(other.CompareTag(MyTagsLayers.ICEBULLET_TAG)){
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
