using UnityEngine;

public class Bullet : MonoBehaviour {

	public float fuerza;
	public int damage;
	protected Rigidbody rb;
	protected int hitEnemy = 0;

	private float destroyAfterTime = 25f;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void Start () {
		rb.AddRelativeForce (Vector3.up * fuerza, ForceMode.Impulse);
	}

	void Update(){
		destroyAfterTime -= Time.deltaTime;
		if(destroyAfterTime <= 0f){
			Destroy (gameObject);
		}
	}
}
