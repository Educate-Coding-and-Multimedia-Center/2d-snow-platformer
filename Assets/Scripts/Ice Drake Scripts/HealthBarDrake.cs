using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDrake : MonoBehaviour {

	[SerializeField] Slider healthBar;


	void Start () {
		IceDrakeScript drakeHealth = GameObject.FindGameObjectWithTag (MyTagsLayers.BOSS_TAG).GetComponent<IceDrakeScript> ();
		healthBar = GetComponent<Slider> ();
		healthBar.maxValue = drakeHealth.maxHealth;
		healthBar.value = drakeHealth.maxHealth;
	}

	public void SetHealth (int HP){
		healthBar.value = HP;
	}
}
