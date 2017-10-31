using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorExplosion : MonoBehaviour {

    private Rigidbody rb;

	private float power = 10.0f;
	private float radius = 5.0f;
	private float upForce = 1.0f;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
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
			Debug.Log (hit.gameObject.name);
			Rigidbody rig = hit.GetComponent<Rigidbody> ();
			if(rig != null){
				rig.AddExplosionForce (power,explosionPosition,radius,upForce,ForceMode.Impulse);
			}
		}
	}
}
