using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

    private List<GameObject> points = new List<GameObject>();
    public int initialEnemies;
    private int addingEnemies = 0;
    private GameObject spawnPoint;
    public GameObject prefab;

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
		
	}

    public void instantiateEnemies() {
        for (int f = 0; f < (initialEnemies + addingEnemies); f++) {
            spawnPoint = points[Random.Range(0, points.Count)];
            Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
