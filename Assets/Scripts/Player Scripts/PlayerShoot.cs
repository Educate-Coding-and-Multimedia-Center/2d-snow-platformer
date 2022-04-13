using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	[SerializeField] GameObject snowBall;

	float timeShoot = 0.5f;
	bool canShoot = true;

	void Start () {
		
	}
	
	void Update () {
		ShootBullet ();
	}

	void ShootBullet(){
		if (Input.GetKeyDown (KeyCode.J) && canShoot) {
			GameObject bullet = Instantiate (snowBall, transform.position, Quaternion.identity);
			Vector3 tempScale = bullet.transform.localScale;

			if(transform.localScale.x < 0){
				tempScale.x = Mathf.Abs (tempScale.x);
			}
			bullet.transform.localScale = tempScale;
			bullet.GetComponent<SnowballBullet> ().Speed *= transform.localScale.x;

			canShoot = false;

			StartCoroutine(WaitForShoot (timeShoot));
		}
	}

	IEnumerator WaitForShoot(float time){
		yield return new WaitForSeconds (time);
		canShoot = true;
	}
}
