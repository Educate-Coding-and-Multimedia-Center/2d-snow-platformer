﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	[SerializeField] float resetSpeed = 0.5f;
	[SerializeField] float cameraSpeed = 0.3f;

	//Bounds cameraBounds;
	Transform target;

	float offSetZ;
	Vector3 lastTargetPos, currentVelocity;
	bool followPlayer;

	void Awake(){
		//isTrigger = enabled
		BoxCollider2D boxCol2d = GetComponent<BoxCollider2D> ();
		boxCol2d.size = new Vector2 (Camera.main.aspect * 3f *
									Camera.main.orthographicSize, 15f);
		//cameraBounds = boxCol2d.bounds;
	}

	void Start () {
		target = GameObject.FindGameObjectWithTag (MyTagsLayers.PLAYER_TAG).transform;
		lastTargetPos = target.position;
		offSetZ = (transform.position - target.position).z;
		followPlayer = true;
	}
	
	void Update () {
		if (followPlayer) {
			Vector3 aheadTargetPos = target.position + Vector3.forward * offSetZ;

			if (aheadTargetPos.x > transform.position.x) {
				Vector3 newCamPos = Vector3.SmoothDamp (transform.position,
														aheadTargetPos,
														ref currentVelocity,
														cameraSpeed);
				transform.position = new Vector3 (newCamPos.x, transform.position.y, newCamPos.z);
				lastTargetPos = target.position;
			}
		}
	}
}
