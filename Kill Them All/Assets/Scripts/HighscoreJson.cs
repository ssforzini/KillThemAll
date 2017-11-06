using System.Collections;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreJson : MonoBehaviour {

	private string path;
	private string highscoreText;
	private string[] firstHighscoreArray;
	[HideInInspector]
	public string[,] secondHighscoreArray = new string[10,2];
	public Button saveHS;

	public GameObject panel;
	public GameObject inputText;
	public GameObject highscoreCanvas;

	private bool deadHS = false;
	private int playerScore;

	private Text HighscoreTextFirst;
	private Text HighscoreTextSecond;

	// Use this for initialization
	void Start () {
		path = Application.streamingAssetsPath + "/Test.txt";
		highscoreText = File.ReadAllText (path);
		firstHighscoreArray = highscoreText.Split (';');
		for(int i = 0; i < firstHighscoreArray.Length; i++){
			secondHighscoreArray [i,0] = firstHighscoreArray [i].Split ('|')[0];
			secondHighscoreArray [i,1] = firstHighscoreArray [i].Split ('|')[1];
		}

		if(SceneManager.GetActiveScene().name == "Main Menu"){
			HighscoreTextFirst = GameObject.Find ("HighscoreText1").GetComponent<Text> ();
			HighscoreTextSecond = GameObject.Find ("HighscoreText2").GetComponent<Text> ();

			string firstText = readFile (1);
			string secondText = readFile (2);

			HighscoreTextFirst.text = firstText;
			HighscoreTextSecond.text = secondText;
		}
	}

	void Update(){
		if(saveHS != null){
			saveHS.onClick.AddListener (SaveHighscore);
		}
	}

	void SaveHighscore(){
		if(inputText.GetComponent<Text> ().text != "" && deadHS == false){
			deadHS = true;
			string name = inputText.GetComponent<Text> ().text;
			writeOnFile (playerScore,name);
			SceneManager.LoadScene ("Main Menu");
		}
	}

	public void activateInputs(bool active,int score = 0){
		playerScore = score;
		panel.SetActive (active);
		highscoreCanvas.SetActive (active);
	}

	public void writeOnFile(int score,string name){
		secondHighscoreArray [9,1] = score.ToString ();
		secondHighscoreArray [9,0] = name;

		string savingText = "";
		orderArray ();

		for(int i = 0; i < 10; i++){
			savingText += secondHighscoreArray [i, 0] + "|" + secondHighscoreArray [i, 1] + ";";
		}
		savingText = savingText.Remove(savingText.Length - 1);
		File.WriteAllText (path,savingText);

	}

	private void orderArray(){

		for(int j = 9; j > 0; j--){
			if(int.Parse(secondHighscoreArray [j, 1]) > int.Parse(secondHighscoreArray [j-1, 1])){
				string tempScore = secondHighscoreArray [j - 1, 1];
				string tempName = secondHighscoreArray [j - 1, 0];
				secondHighscoreArray [j - 1, 0] = secondHighscoreArray [j, 0];
				secondHighscoreArray [j - 1, 1] = secondHighscoreArray [j, 1];
				secondHighscoreArray [j, 0] = tempName;
				secondHighscoreArray [j, 1] = tempScore;
			}
		}

	}

	private string readFile(int type){
		string value = "";
		if (type == 1) {
			value += "1) " + secondHighscoreArray[0,0] + " - " + secondHighscoreArray[0,1] + "\n";
			value += "2) " + secondHighscoreArray[1,0] + " - " + secondHighscoreArray[1,1] + "\n";
			value += "3) " + secondHighscoreArray[2,0] + " - " + secondHighscoreArray[2,1] + "\n";
			value += "4) " + secondHighscoreArray[3,0] + " - " + secondHighscoreArray[3,1] + "\n";
			value += "5) " + secondHighscoreArray[4,0] + " - " + secondHighscoreArray[4,1] + "\n";
		} else {
			value += "6) " + secondHighscoreArray[5,0] + " - " + secondHighscoreArray[5,1] + "\n";
			value += "7) " + secondHighscoreArray[6,0] + " - " + secondHighscoreArray[6,1] + "\n";
			value += "8) " + secondHighscoreArray[7,0] + " - " + secondHighscoreArray[7,1] + "\n";
			value += "9) " + secondHighscoreArray[8,0] + " - " + secondHighscoreArray[8,1] + "\n";
			value += "10) " + secondHighscoreArray[9,0] + " - " + secondHighscoreArray[9,1] + "\n";
		}

		return value;
	}
}
