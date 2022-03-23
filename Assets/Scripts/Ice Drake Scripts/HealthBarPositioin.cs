using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPositioin : MonoBehaviour {

	[SerializeField] GameObject iceDrake;

	[SerializeField] Vector2 offset;

	Vector2 pos;

	void Update () {
		pos = iceDrake.transform.position;
		transform.position = pos + offset;
	}
}
