using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private Rigidbody rb;
    private MeshRenderer mr;

	[SerializeField]private float movementSpeed;
	[SerializeField]private float rotationSpeed;
	private int life = 50;
	public GameObject prefab;
	public Transform puntoSalida;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mr.enabled) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                Instantiate(prefab, puntoSalida.position, puntoSalida.rotation);
            }
			if(Input.GetKeyDown(KeyCode.Escape)){
				SceneManager.LoadScene ("Main Menu");
			}
        }
		

        if (life < 0) {
            mr.enabled = false;
        }
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemies"){
            int enemyAtack = col.gameObject.GetComponent<SimpleEnemy>().getAtack();
            life -= enemyAtack;
            if (life < 0) {
                mr.enabled = false;
				SceneManager.LoadScene ("Main Menu");
            }
        }
	}
}
