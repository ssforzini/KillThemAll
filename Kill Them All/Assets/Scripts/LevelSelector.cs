using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	public Button level1;
	public Button level2;
    public Button level3;
	
	// Update is called once per frame
	void Update () {
		level1.onClick.AddListener (FirstLevel);
		level2.onClick.AddListener (SecondLevel);
        level3.onClick.AddListener(ThirdLevel);
    }

	void FirstLevel(){ 
		SceneManager.LoadScene ("Scene");
	}
	void SecondLevel(){ 
		SceneManager.LoadScene ("Scene2"); 
	}
    void ThirdLevel()
    {
        SceneManager.LoadScene("Scene3");
    }
}
