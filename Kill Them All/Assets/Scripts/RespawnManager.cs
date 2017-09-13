using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

    private List<GameObject> points = new List<GameObject>();
    public int initialEnemies;
    private int addingEnemies = 0;
	private int wave = 1;
    private GameObject spawnPoint;
    public GameObject prefab;
	[HideInInspector]
	public int enemyCount;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < GameObject.Find("SpawnPlaces").transform.childCount; i++) {
            GameObject go = GameObject.Find("SpawnPlaces").transform.GetChild(i).gameObject;
            points.Add(go);
        }

        instantiateEnemies();
    }

    // Update is called once per frame
    void Update () {
		if(enemyCount == 0){
			wave++;
			Debug.Log ("Wave: " + wave.ToString());
			addingEnemies += 2;
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
}
