using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

	[SerializeField] Text lifeText;

	SpriteRenderer sr;

	int lifeScoreCount;
	bool canDamage;

	void Awake(){
		lifeScoreCount = 3;
		canDamage = true;
		sr = GetComponent<SpriteRenderer> ();

		lifeText = GameObject.Find ("Life Player Text").GetComponent<Text> ();
		lifeText.text = "x" + lifeScoreCount.ToString ();
	}

	void Start () {
		Time.timeScale = 1f;
	}
	
	void Update () {
		
	}

	public void DealDamage(){
		if (canDamage) {

			lifeScoreCount--;

			StartCoroutine (BlinkPlayer (0.1f));

			if(lifeScoreCount >= 0){
				lifeText.text = "x" + lifeScoreCount.ToString ();
			}

			if (lifeScoreCount <= 0) {
				Time.timeScale = 0f;
				StartCoroutine (RestartGame(2f));
			}

			canDamage = false;
			StartCoroutine (WaitCanDamage ());
		}
	}

	IEnumerator WaitCanDamage(){
		yield return new WaitForSeconds (2f);
		canDamage = true;
	}

	IEnumerator RestartGame(float time){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (0);
	}

	IEnumerator BlinkPlayer(float time){
		Color temp = sr.color;

		for (int i = 0; i < 5; i++) {
			temp.a = 0f;

			sr.color = temp;
			yield return new WaitForSeconds(time);

			temp.a = 1f;

			sr.color = temp;
			yield return new WaitForSeconds(time);
		}
	}

}
