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

		GameObject iceBulletObj = Instantiate (iceBullet, temp, Quaternion.identity);
		Vector2 tempScale = transform.localScale;
		tempScale.x *= (transform.localScale.z);
		iceBulletObj.transform.localScale = tempScale;
		iceBulletObj.GetComponent<IceBulletScript>().Speed *= (transform.localScale.z * -1);
	}

}
