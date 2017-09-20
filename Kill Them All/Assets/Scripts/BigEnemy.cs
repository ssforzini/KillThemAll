using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy {

	// Use this for initialization
	void Awake () {
		setLife (350);
		setVelocity (30);
		setDefense (0);
		setAtack(30);
		setSelfScore(100);
	}
}
