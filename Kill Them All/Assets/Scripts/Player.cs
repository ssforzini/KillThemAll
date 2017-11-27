using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	//private Rigidbody rb;
    //private MeshRenderer mr;

	[SerializeField]private float movementSpeed;
	[SerializeField]private float rotationSpeed;
	private int life = 50;

    private int score = 0;
    private Text txt;
    private Slider sl;

	private HighscoreJson hsj;
	private WeaponManager wm;

	private float enemyStay = 2.5f;

	private bool pauseActive = false;

    // Use this for initialization
    void Start () {
		//rb = GetComponent<Rigidbody> ();
        //mr = GetComponent<MeshRenderer>();
		wm = GetComponent<WeaponManager> ();
        txt = GameObject.Find("Score").GetComponent<Text>();
        sl = GameObject.Find("PlayerLife").GetComponent<Slider>();
		txt.text = "Puntaje: " + score.ToString();
		hsj = GameObject.Find ("HighscorePlayer").GetComponent<HighscoreJson>();
    }
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {

            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            transform.Translate(Vector3.back * Time.deltaTime * vertical * movementSpeed);
            transform.Rotate(Vector3.up * Time.deltaTime * horizontal * rotationSpeed);

			if(Input.GetKeyDown(KeyCode.Escape)){
				SceneManager.LoadScene ("Main Menu");
			}

			if(Input.GetKeyDown(KeyCode.P)){
				if (pauseActive) {
					Time.timeScale = 1f;
					pauseActive = false;
				} else {
					Time.timeScale = 0f;
					pauseActive = true;
				}

			}
        }

        if (life < 0) {
			gameObject.SetActive (true);
        }


	}

	void OnCollisionStay(Collision col){
		enemyStay -= Time.deltaTime;
		if((col.gameObject.tag == "Enemies") && gameObject.activeSelf == true && enemyStay <= 0f){
			enemyStay = 2.5f;
			int enemyAtack = col.gameObject.GetComponent<Enemy> ().getAtack () / 2;
			life -= enemyAtack;
			sl.value = life;
			if (life < 0) {
				wm.deadPlayer = true;
				if(score > int.Parse(hsj.secondHighscoreArray[9,1])){
					hsj.activateInputs (true,score);
				} else {
					SceneManager.LoadScene ("Main Menu");
				}
			}
		}
	}

    public void addScore(int _score) {
        score += _score;
        txt.text = "Puntaje: " + score.ToString();
    }

	public void winLife(int _life){
		life += _life;
		if(life > 50){
			life = 50;
		}
		sl.value = life;
	}
}
