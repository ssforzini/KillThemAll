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
	public GameObject prefabSimpleEnemy;
	public GameObject prefabFastEnemy;
	public GameObject prefabBigEnemy;
	public GameObject medicBoxPrefab;
	public GameObject[] weaponGrab;

	public GameObject[] weaponsPrefab;
	private Text waveCountText;

	[HideInInspector]
	public int enemyCount;
    private Text txt;
    private float timeText = 0f;

	private float objectAppearence = 35f;

	private AudioSource nextWaveSound;

	private int fastEnemyWaveAppearence = 5;
	private int fastEnemyRest = 7;
	private int bigEnemyWaveAppearence = 20;	private int bigEnemyRest = 9;

    // Use this for initialization
	void Start () {
        for (int i = 0; i < GameObject.Find("SpawnPlaces").transform.childCount; i++) {
            GameObject go = GameObject.Find("SpawnPlaces").transform.GetChild(i).gameObject;
            points.Add(go);
        }

        txt = GameObject.Find("Wave").GetComponent<Text>();
		waveCountText = GameObject.Find ("WaveCount").GetComponent<Text> ();
		nextWaveSound = GameObject.Find ("NextWave").GetComponent<AudioSource> ();

		showWaveText();
		instantiateObjects ();
        instantiateEnemies();
    }

    // Update is called once per frame
    void Update () {
        if(timeText > 0f) {
            timeText -= Time.deltaTime;
        } else {
            txt.text = "";
        }

		if (objectAppearence > 0f) {
			objectAppearence -= Time.deltaTime;
		} else {
			instantiateObjects ();
			objectAppearence = 35f;
		}

		waveCountText.text = enemyCount.ToString();

		if(enemyCount == 0){
			nextWaveSound.Play ();
			wave++;
			changeEnemyRest (wave);
			addingEnemies += 2;
            showWaveText();
			instantiateObjects ();
            instantiateEnemies ();
		}
	}

    public void instantiateEnemies() {
		
		enemyCount = initialEnemies + addingEnemies;
        for (int f = 0; f < (initialEnemies + addingEnemies); f++) {
            spawnPoint = points[Random.Range(0, points.Count)];
			if(Random.Range(0, points.Count) % fastEnemyRest == 0 && wave >= fastEnemyWaveAppearence){
				Instantiate(prefabFastEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
			} else if(Random.Range(0, points.Count) % bigEnemyRest == 0 && wave >= bigEnemyWaveAppearence){
				Instantiate(prefabBigEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
			} else {
				Instantiate(prefabSimpleEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
			}

        }
    }

	public void enemyCountDecrease(){
		enemyCount--;
	}

    public void showWaveText() {
        txt.text = "WAVE " + wave.ToString();
        timeText = 2f;
    }

	public void changeEnemyRest(int _wave){
		switch (_wave) {
		case 20:
			bigEnemyRest = 8;
			fastEnemyRest = 6;
		break;
		case 25:
			bigEnemyRest = 7;
			fastEnemyRest = 4;
		break;
		case 30:
			bigEnemyRest = 6;
			fastEnemyRest = 3;
		break;
		case 35:
			bigEnemyRest = 4;
			fastEnemyRest = 2;
		break;
		}
	}

	public void instantiateObjects(){
		GameObject weaponGrabPoint = weaponGrab [Random.Range (0, weaponGrab.Length)];
		Instantiate (weaponsPrefab[Random.Range(0,weaponsPrefab.Length)], weaponGrabPoint.transform.position, weaponGrabPoint.transform.rotation);
	}
}
