using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet {

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Walls"){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.tag);
		if (col.gameObject.tag == "Enemies" && hitEnemy == 0) {
			hitEnemy = 1;
			Enemy enemy = col.gameObject.GetComponent<Enemy> ();
			enemy.takeLife (damage);
			Destroy (gameObject);
		}
	}
}
