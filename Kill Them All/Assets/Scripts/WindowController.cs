using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowController : MonoBehaviour {

	public GameObject[] windows;
	public Button[] buttons;
	private int activeWindow;

	void Start(){
		activeWindow = 1;
		activeWindows (true,false,false);
	}
	
	// Update is called once per frame
	void Update () {
		switch(activeWindow){
		case 1:
			buttons[0].onClick.AddListener (PlayClick);
			buttons[2].onClick.AddListener (ExitClick);
			buttons[1].onClick.AddListener (HighscoreClick);
		break;
		case 2:
			buttons[3].onClick.AddListener (FirstLevel);
			buttons[4].onClick.AddListener (SecondLevel);
			buttons[5].onClick.AddListener(ThirdLevel);
		break;
		case 3:
			buttons[6].onClick.AddListener (MainMenuClick);	
		break;
		}
		
	}

	void PlayClick(){
		activeWindow = 2;
		activeWindows (false,false,true);
	}

	void HighscoreClick(){
		activeWindow = 3;
		activeWindows (false,true,false);
	}

	void ExitClick(){
		Application.Quit ();
	}

	void FirstLevel(){ 
		SceneManager.LoadScene ("Scene");
	}

	void SecondLevel(){ 
		SceneManager.LoadScene ("Scene2"); 
	}

	void ThirdLevel(){
		SceneManager.LoadScene("Scene3");
	}

	void MainMenuClick(){
		activeWindow = 1;
		activeWindows (true,false,false);
	}

	private void activeWindows(bool mainMenu, bool highscoreMenu, bool levelMenu){
		windows [0].SetActive (mainMenu);
		windows [1].SetActive (highscoreMenu);
		windows [2].SetActive (levelMenu);
	}
}
