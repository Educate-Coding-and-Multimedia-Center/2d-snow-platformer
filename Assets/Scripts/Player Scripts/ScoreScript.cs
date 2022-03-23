using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	
	private Text coinScoreText;
	private int scoreCount;

	[SerializeField] AudioClip coinSound;

	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();

		coinScoreText = GameObject.Find ("Coin Text").GetComponent<Text> ();
		scoreCount = 0;
		coinScoreText.text = scoreCount.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == MyTagsLayers.COIN_TAG) {
			other.gameObject.SetActive (false);
			scoreCount++;

			audioSource.PlayOneShot (coinSound);
			coinScoreText.text = scoreCount.ToString ();

		}
	}
}
