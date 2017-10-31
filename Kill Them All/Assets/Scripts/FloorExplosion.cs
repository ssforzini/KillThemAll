using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorExplosion : MonoBehaviour {

    private Rigidbody rb;
	private GameObject prc;

	private int damage = 100;
	private float power = 10000.0f;
	private float radius = 40.0f;
	private float upForce = 100.0f;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

		foreach (Transform t in transform) {
			prc = t.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Enemies") {
			Invoke ("Detonate",1);
        }
    }

	void Detonate(){
		Vector3 explosionPosition = gameObject.transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPosition,radius);
		foreach(Collider hit in colliders){
			if(hit.gameObject.tag == "Enemies"){
				prc.SetActive (true);
				hit.GetComponent<Enemy> ().takeLife (damage);
			}
		}

		Invoke ("DestroyAfterFive",5);
	}

	void DestroyAfterFive(){
		Destroy (gameObject);
	}
}
