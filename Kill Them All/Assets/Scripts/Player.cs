using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Rigidbody rb;
    private MeshRenderer mr;

	[SerializeField]private float movementSpeed;
	[SerializeField]private float rotationSpeed;
	private int life = 50;
	public GameObject prefab;
	public Transform puntoSalida;
    private int score = 0;
    private Text txt;
    private Slider sl;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        mr = GetComponent<MeshRenderer>();
        txt = GameObject.Find("Score").GetComponent<Text>();
        sl = GameObject.Find("PlayerLife").GetComponent<Slider>();
        txt.text = score.ToString();
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
			int enemyAtack = col.gameObject.GetComponent<Enemy>().getAtack();
            life -= enemyAtack;
            sl.value = life;
            if (life < 0) {
                mr.enabled = false;
				SceneManager.LoadScene ("Main Menu");
            }
        }
	}

    public void addScore(int _score) {
        score += _score;
        txt.text = score.ToString();
    }
}
