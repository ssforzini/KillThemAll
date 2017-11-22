using UnityEngine;

public class Bullet : MonoBehaviour {

	public float fuerza;
	public int damage;
	private Rigidbody rb;
	private int hitEnemy = 0;

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
		if(col.gameObject.tag == "Enemies" && hitEnemy == 0){
			hitEnemy = 1;
			col.gameObject.GetComponent<Enemy> ().takeLife (damage);
		}
		Destroy (gameObject);
	}
}
