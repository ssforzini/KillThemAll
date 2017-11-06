using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button playButton;
	public Button exitButton;
	public Button highscoreButton;
	
	// Update is called once per frame
	void Update () {
		playButton.onClick.AddListener (PlayClick);
		exitButton.onClick.AddListener (ExitClick);
		highscoreButton.onClick.AddListener (HighscoreClick);
			
	}

	void PlayClick(){
		SceneManager.LoadScene ("Levels");
	}

	void HighscoreClick(){
		SceneManager.LoadScene ("Highscore");
	}

	void ExitClick(){
		Application.Quit ();
	}
}
