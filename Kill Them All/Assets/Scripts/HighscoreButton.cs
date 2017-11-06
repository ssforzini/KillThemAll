using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreButton : MonoBehaviour {

	public Button highscoreButton;
	
	// Update is called once per frame
	void Update () {
		highscoreButton.onClick.AddListener (HighscoreClick);		
	}

	void HighscoreClick(){
		SceneManager.LoadScene ("Main Menu");
	}
}
