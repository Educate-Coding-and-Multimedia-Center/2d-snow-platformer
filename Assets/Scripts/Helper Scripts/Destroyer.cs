using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	[SerializeField] GameObject player;

	void Start () {
		
	}
	
	void Update () {
		transform.position = new Vector2 (player.transform.position.x, player.transform.position.y - 10f);
	}
}
