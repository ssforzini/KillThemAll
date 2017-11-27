using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet {

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemies" && hitEnemy == 0){
			hitEnemy = 1;
			col.gameObject.GetComponent<Enemy> ().takeLife (damage);
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "Walls"){
			Destroy (gameObject);
		}
	}
}
