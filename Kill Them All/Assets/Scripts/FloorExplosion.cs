using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorExplosion : MonoBehaviour {

    private Rigidbody rb;
	private GameObject prc;

	private int damage = 100;
	private float power = 10000.0f;
	private float radius = 55.0f;
	private float upForce = 100.0f;

	private int active = 0;

	private AudioSource explosionSound;

	private GameObject bt;

	// Use this for initialization
	void Start () {
		explosionSound = GameObject.Find ("ExplosionSound").GetComponent<AudioSource> ();
        rb = gameObject.GetComponent<Rigidbody>();

		foreach (Transform t in transform) {
			if (t.gameObject.tag == "ParticleC4") {
				prc = t.gameObject;
			} else if(t.gameObject.tag == "CountC4"){
				bt = t.gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Enemies" && active == 0) {
			bt.SetActive (true);
			bt.GetComponent<BombTime>().bombActive = 1;
			Invoke ("Detonate",3);
        }
    }

	void Detonate(){
		if(active == 0){
			active = 1;
			explosionSound.Play ();
			prc.SetActive (true);
			Vector3 explosionPosition = gameObject.transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPosition,radius);
			foreach(Collider hit in colliders){
				if(hit.gameObject.tag == "Enemies"){
					hit.GetComponent<Enemy> ().takeLife (damage);
				}
			}

			Invoke ("DestroyAfterFive",5);
		}

	}

	void DestroyAfterFive(){
		Destroy (gameObject);
	}
}
