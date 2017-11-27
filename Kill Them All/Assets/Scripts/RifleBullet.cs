using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : Bullet {

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Walls"){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Enemies"){
			hitEnemy = 1;
			col.gameObject.GetComponent<Enemy> ().takeLife (damage);
		}
	}
}
