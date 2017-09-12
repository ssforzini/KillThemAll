using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody rb;
	[SerializeField]private float movementSpeed;
	[SerializeField]private float rotationSpeed;
	private int life = 50;
	public GameObject prefab;
	public Transform puntoSalida;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate (Vector3.back * Time.deltaTime * movementSpeed);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate (Vector3.down * Time.deltaTime * rotationSpeed);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate (prefab, puntoSalida.position, puntoSalida.rotation);
		}
	}

	/*void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemies"){
			col.gameObject.GetComponent<SimpleEnemy> ().takeLife (damage);
		}
		Destroy (gameObject);
	}*/
}
