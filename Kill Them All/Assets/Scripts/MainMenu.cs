using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button playButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playButton.onClick.AddListener (PlayClick);
		exitButton.onClick.AddListener (ExitClick);
			
	}

	void PlayClick(){
		SceneManager.LoadScene ("Scene");
	}

	void ExitClick(){
		Application.Quit ();
	}
}
