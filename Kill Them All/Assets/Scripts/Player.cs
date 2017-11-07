using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	//private Rigidbody rb;
    private MeshRenderer mr;

	[SerializeField]private float movementSpeed;
	[SerializeField]private float rotationSpeed;
	private int life = 50;

    private int score = 0;
    private Text txt;
    private Slider sl;

	private HighscoreJson hsj;
	private WeaponManager wm;

    // Use this for initialization
    void Start () {
		//rb = GetComponent<Rigidbody> ();
        mr = GetComponent<MeshRenderer>();
		wm = GetComponent<WeaponManager> ();
        txt = GameObject.Find("Score").GetComponent<Text>();
        sl = GameObject.Find("PlayerLife").GetComponent<Slider>();
        txt.text = score.ToString();
		hsj = GameObject.Find ("HighscorePlayer").GetComponent<HighscoreJson>();
    }
	
	// Update is called once per frame
	void Update () {
        if (mr.enabled) {

            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            transform.Translate(Vector3.back * Time.deltaTime * vertical * movementSpeed);
            transform.Rotate(Vector3.up * Time.deltaTime * horizontal * rotationSpeed);

			if(Input.GetKeyDown(KeyCode.Escape)){
				SceneManager.LoadScene ("Main Menu");
			}
        }

        if (life < 0) {
            mr.enabled = false;
        }

	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Enemies" && mr.enabled == true){
			int enemyAtack = col.gameObject.GetComponent<Enemy>().getAtack();
            life -= enemyAtack;
            sl.value = life;
            if (life < 0) {
                mr.enabled = false;
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
