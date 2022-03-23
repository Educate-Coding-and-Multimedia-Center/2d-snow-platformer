using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDrakeAttack : MonoBehaviour {

	[SerializeField] float offSetY = 1f;
	[SerializeField] Transform shootLocation;
	[SerializeField] GameObject iceBullet;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FireIceBullet(){
		Vector2 temp = shootLocation.transform.position;
		temp.y = temp.y + Random.Range (-offSetY, offSetY);

		Instantiate (iceBullet, temp, Quaternion.identity);
	}

}
