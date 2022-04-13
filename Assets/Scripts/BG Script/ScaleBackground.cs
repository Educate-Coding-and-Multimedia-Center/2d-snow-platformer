using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour {

	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;

		print (width);
		print (height);

		float worldHeight = Camera.main.orthographicSize * 2f;
		float worldWidth = (worldHeight / Screen.height) * Screen.width;

		print (worldWidth);
		print (worldHeight);

		Vector3 tempScale = transform.localScale;
		tempScale.x = worldWidth / width + 0.1f;
		tempScale.y = worldHeight / height + 0.1f;

		transform.localScale = tempScale;
	}
	
}
