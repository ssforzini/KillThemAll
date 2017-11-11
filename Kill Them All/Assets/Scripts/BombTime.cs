using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTime : MonoBehaviour {

	public Material[] materials;
	private Renderer rend;
	private float time = 0.7f;
	private int actualMaterial = 2;
	[HideInInspector]
	public int bombActive = 0;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(bombActive == 1){
			time -= Time.deltaTime;

			if(time <= 0){
				if(actualMaterial >= 0){
					rend.sharedMaterial = materials[actualMaterial];
					time = 0.7f;
					actualMaterial--;
				} else {
					gameObject.SetActive (false);
				}

			}
		}
	}
}
