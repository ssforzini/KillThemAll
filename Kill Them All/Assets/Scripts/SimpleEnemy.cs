using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {

	// Use this for initialization
	void Awake () {
		setLife (50);
		setVelocity (45);
		setDefense (0);
        setAtack(8);
        setSelfScore(15);
	}
}
