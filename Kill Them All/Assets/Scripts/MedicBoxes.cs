using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicBoxes : MonoBehaviour {

	private int points = 20;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 80);
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.name == "Player"){
			col.GetComponent<Player> ().winLife (points);
			Destroy (gameObject);
		}
	}
}
