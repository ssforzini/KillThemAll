using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseWindowController : MonoBehaviour {

	public GameObject[] windows;
	public GameObject pauseCanvas;
	public Button[] buttons;
	private int activeWindow;
	private HighscoreJson hsj;

	public Text firstHSText;
	public Text secondHSText;

	void Start(){
		hsj = GameObject.Find ("HighscorePlayer").GetComponent<HighscoreJson>();

		activeWindow = 1;
		activeWindows (true,false,false);
		Time.timeScale = 1;
		pauseCanvas.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0f) {
			if(!pauseCanvas.activeSelf){
				pauseCanvas.SetActive (true);
			}
			switch (activeWindow) {
			case 1: //MENU PRINCIPAL
				buttons [0].onClick.AddListener (ControlClick);
				buttons [1].onClick.AddListener (HighscoreClick);
				buttons [2].onClick.AddListener (MainMenuClick);
				buttons [3].onClick.AddListener (PlayClick);
				break;
			case 2: //LEVEL
				buttons [4].onClick.AddListener (PauseMenuClick);	
				break;
			case 3: //HIGHSCORE
				buttons [5].onClick.AddListener (PauseMenuClick);
				break;
			}
		}
	}

	void ControlClick(){
		activeWindow = 2;
		activeWindows (false,true,false);
	}

	void HighscoreClick(){
		activeWindow = 3;
		activeWindows (false,false,true);

		firstHSText.text = hsj.readFile (1);
		secondHSText.text = hsj.readFile (2);
	}

	void MainMenuClick(){
		SceneManager.LoadScene ("Main Menu");
	}

	void PauseMenuClick(){
		activeWindow = 1;
		activeWindows (true,false,false);
	}

	void PlayClick(){
		Time.timeScale = 1;
		pauseCanvas.SetActive (false);
	}

	private void activeWindows(bool mainMenu, bool controlMenu, bool highscoreMenu){
		windows [0].SetActive (mainMenu);
		windows [1].SetActive (controlMenu);
		windows [2].SetActive (highscoreMenu);
	}
}
