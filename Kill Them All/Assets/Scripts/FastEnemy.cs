using UnityEngine;

public class FastEnemy : Enemy {

	// Use this for initialization
	void Awake () {
		setLife (25);
		setVelocity (100);
		setDefense (0);
		setAtack(5);
		setSelfScore(20);
	}
}
