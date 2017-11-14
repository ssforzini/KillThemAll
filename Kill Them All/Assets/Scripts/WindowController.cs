using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowController : MonoBehaviour {

	public GameObject[] windows;
	public Button[] buttons;
	private int activeWindow;

	[HideInInspector]
	public int selectedLevel;

	void Start(){
		selectedLevel = 0;
		activeWindow = 1;
		activeWindows (true,false,false,false,false);
	}
	
	// Update is called once per frame
	void Update () {
		switch(activeWindow){
		case 1: //MENU PRINCIPAL
			buttons[0].onClick.AddListener (PlayClick);
			buttons[2].onClick.AddListener (ExitClick);
			buttons[1].onClick.AddListener (HighscoreClick);
			buttons[7].onClick.AddListener (ControlClick);
			buttons[8].onClick.AddListener (CreditClick);
		break;
		case 2: //LEVEL
			buttons[3].onClick.AddListener (FirstLevel);
			buttons[4].onClick.AddListener (SecondLevel);
			buttons[5].onClick.AddListener(ThirdLevel);
			buttons[11].onClick.AddListener (MainMenuClick);	
		break;
		case 3: //HIGHSCORE
			buttons[6].onClick.AddListener (MainMenuClick);	
			break;
		case 4: //CONTROLES
			buttons[9].onClick.AddListener (MainMenuClick);	
			break;
		case 5: //CREDITOS
			buttons[10].onClick.AddListener (MainMenuClick);	
			break;
		}
		
	}

	void PlayClick(){
		activeWindow = 2;
		activeWindows (false,false,true,false,false);
	}

	void HighscoreClick(){
		activeWindow = 3;
		activeWindows (false,true,false,false,false);
	}

	void MainMenuClick(){
		activeWindow = 1;
		activeWindows (true,false,false,false,false);
	}

	void ControlClick(){
		activeWindow = 4;
		activeWindows (false,false,false,true,false);
	}

	void CreditClick(){
		activeWindow = 5;
		activeWindows (false,false,false,false,true);
	}

	void ExitClick(){
		Application.Quit ();
	}

	void FirstLevel(){ 
		selectedLevel = 1;
		activeWindows (false,false,false,false,false);
		//SceneManager.LoadScene ("Scene");
	}

	void SecondLevel(){ 
		selectedLevel = 2;
		activeWindows (false,false,false,false,false);
		//SceneManager.LoadScene ("Scene2"); 
	}

	void ThirdLevel(){
		selectedLevel = 3;
		activeWindows (false,false,false,false,false);
		//SceneManager.LoadScene("Scene3");
	}

	private void activeWindows(bool mainMenu, bool highscoreMenu, bool levelMenu,bool controlMenu, bool creditMenu){
		windows [0].SetActive (mainMenu);
		windows [1].SetActive (highscoreMenu);
		windows [2].SetActive (levelMenu);
		windows [3].SetActive (controlMenu);
		windows [4].SetActive (creditMenu);
	}
}
