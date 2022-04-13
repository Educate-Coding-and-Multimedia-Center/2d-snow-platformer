﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	public void DestroyExplosionIceBullet(){
		Destroy (gameObject);
	}

	public void DeactivateBoss(){
		gameObject.SetActive (false);
	}
}
