using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour {

    private List<GameObject> points = new List<GameObject>();
    public int initialEnemies;
    private int addingEnemies = 0;
	private int wave = 1;
    private GameObject spawnPoint;
    public GameObject prefab;
	[HideInInspector]
	public int enemyCount;
    private Text txt;
    private float timeText = 0f;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < GameObject.Find("SpawnPlaces").transform.childCount; i++) {
            GameObject go = GameObject.Find("SpawnPlaces").transform.GetChild(i).gameObject;
            points.Add(go);
        }

        txt = GameObject.Find("Wave").GetComponent<Text>();

        showWaveText();
        instantiateEnemies();
    }

    // Update is called once per frame
    void Update () {
        if(timeText > 0f) {
            timeText -= Time.deltaTime;
        } else {
            txt.text = "";
        }

		if(enemyCount == 0){
			wave++;
			addingEnemies += 2;
            showWaveText();
            instantiateEnemies ();
		}
	}

    public void instantiateEnemies() {
		enemyCount = initialEnemies + addingEnemies;
        for (int f = 0; f < (initialEnemies + addingEnemies); f++) {
            spawnPoint = points[Random.Range(0, points.Count)];
            Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

	public void enemyCountDecrease(){
		enemyCount--;
	}

    public void showWaveText() {
        txt.text = "WAVE " + wave.ToString();
        timeText = 2f;
    }
}
