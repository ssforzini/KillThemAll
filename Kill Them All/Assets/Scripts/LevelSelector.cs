using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	public Button level1;
	public Button level2;
	
	// Update is called once per frame
	void Update () {
		level1.onClick.AddListener (FirstLevel);
		level2.onClick.AddListener (SecondLevel);
	}

	void FirstLevel(){ 
		SceneManager.LoadScene ("Scene");
	}
	void SecondLevel(){ 
		SceneManager.LoadScene ("Scene2"); 
	}
}
