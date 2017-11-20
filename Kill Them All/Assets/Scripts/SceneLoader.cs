using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private bool loadScene = false;

	[SerializeField]
	private int scene;
	private GameObject loadingText;
	private MainMenuWindowController wc;
	private int alreadyLoad;

	void Start(){
		alreadyLoad = 0;
		loadingText = GameObject.Find ("Loading");
		if(loadingText != null){
			loadingText.SetActive (false);	
		}
		wc = GameObject.Find ("MainMenuManager").GetComponent<MainMenuWindowController> ();
	}

	// Updates once per frame
	void Update() {

		// If the player has pressed the space bar and a new scene is not loading yet...
		if (loadScene == false && wc.selectedLevel != 0) {

			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			if(loadingText != null){
				loadingText.SetActive(true);
			}

			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

	}


	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		if(SceneManager.GetActiveScene().name == "Main Menu" && alreadyLoad == 0){
			alreadyLoad = 1;
			//yield return new WaitForSeconds(3);
			AsyncOperation async = null;
			// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
			if (wc.selectedLevel == 1) {
				async = Application.LoadLevelAsync ("Scene");
			} else if (wc.selectedLevel == 2) {
				async = Application.LoadLevelAsync ("Scene2");
			} else if (wc.selectedLevel == 3) {
				async = Application.LoadLevelAsync ("Scene3");
			} 
			loadScene = false;
			// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
			while (!async.isDone) {
				yield return null;
			}
		}
	}
}
