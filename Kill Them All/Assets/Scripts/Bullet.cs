using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float fuerza;
	public int damage;
	private Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		rb.AddRelativeForce (Vector3.back * fuerza, ForceMode.Impulse);
	}

	void Update(){
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemies"){
			col.gameObject.GetComponent<SimpleEnemy> ().takeLife (damage);
		}
		Destroy (gameObject);
	}
}
