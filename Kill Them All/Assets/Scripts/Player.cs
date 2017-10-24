using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	//private Rigidbody rb;
    private MeshRenderer mr;

	[SerializeField]private float movementSpeed;
	[SerializeField]private float rotationSpeed;
	private int life = 50;

	public WeaponManager wmanager;

    private int score = 0;
    private Text txt;
    private Slider sl;

    // Use this for initialization
    void Start () {
		//rb = GetComponent<Rigidbody> ();
        mr = GetComponent<MeshRenderer>();
        txt = GameObject.Find("Score").GetComponent<Text>();
        sl = GameObject.Find("PlayerLife").GetComponent<Slider>();
        txt.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (mr.enabled) {

            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            transform.Translate(Vector3.back * Time.deltaTime * vertical * movementSpeed);
            transform.Rotate(Vector3.up * Time.deltaTime * horizontal * rotationSpeed);


			/*if ((Input.GetButton("Fire") && actualGun == 2) && /*uziFire 0 <= 0) {
				Instantiate(prefab, puntoSalida.position, puntoSalida.rotation);
                /*uziFire = 0.15f;
			}*/
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

	public void winLife(int _life){
		life += _life;
		if(life > 50){
			life = 50;
		}
		sl.value = life;
	}
}
