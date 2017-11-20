using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuWindowController : MonoBehaviour {

	private int actualAction = 0;
	private int levelAction = 0;
	public GameObject[] fingerSelectArray;
	public GameObject[] levelArray;
	public GameObject[] windows;
	private int activeWindow;

	[HideInInspector]
	public int selectedLevel;

	// Use this for initialization
	void Start () {
		selectedLevel = 0;
		activeWindow = 0;
		activateFingerSelect ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.DownArrow) && (actualAction >= 0 && actualAction < 3) && activeWindow == 0) {
			actualAction++;
		} else if(Input.GetKeyDown (KeyCode.UpArrow) && (actualAction > 0 && actualAction <= 3) && activeWindow == 0){
			actualAction--;
		} else if(Input.GetKeyDown (KeyCode.RightArrow) && (levelAction >= 0 && levelAction < 2) && activeWindow == 1){
			levelAction++;
		} else if(Input.GetKeyDown (KeyCode.LeftArrow) && (levelAction > 0 && levelAction <= 2) && activeWindow == 1){
			levelAction--;
		} else if(Input.GetKeyDown (KeyCode.Space)){
			if (activeWindow == 0) {
				if (actualAction != 3) {
					activeWindow = actualAction + 1;
					activeWindows ();
				} else {
					Application.Quit ();
				}
			} else if(activeWindow == 1) {
				selectedLevel = levelAction + 1;
				activeWindows ();
			}

		} else if(Input.GetKeyDown (KeyCode.Escape) && activeWindow != 0){
			activeWindow = 0;
			activeWindows ();
		}

		if(activeWindow == 0){
			activateFingerSelect ();	
		}
		if(activeWindow == 1){
			activateLevel ();
		}

	}

	private void activateFingerSelect(){
		for(int i = 0; i < fingerSelectArray.Length; i++){
			if(i == actualAction){
				fingerSelectArray [i].SetActive (true);
			} else {
				fingerSelectArray [i].SetActive (false);
			}
		}
	}

	private void activateLevel(){
		for(int l = 0; l < levelArray.Length; l++){
			if(l == levelAction){
				levelArray [l].SetActive (false);
			} else {
				levelArray [l].SetActive (true);
			}
		}
	}

	private void activeWindows(){
		for (int j = 0; j < windows.Length; j++) {
			if (selectedLevel != 0) {
				windows [j].SetActive (false);
			} else {
				if (activeWindow == j) {
					windows [j].SetActive (true);
				} else {
					windows [j].SetActive (false);
				}
			}
		}
	}
}
