using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorExplosion : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Enemies") {
            col.GetComponent<Rigidbody>().AddExplosionForce(15000f, transform.position, 15000f);
            //Destroy(gameObject);
        }

    }
}
