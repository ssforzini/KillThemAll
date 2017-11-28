using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualGunImages : MonoBehaviour {

	[HideInInspector]
	public int activeGun;
	private GameObject gunImage;
	private GameObject uziImage;
	private GameObject bombImage;
	private GameObject rifleImage;
	private GameObject shotgunImage;


	// Use this for initialization
	void Start () {
		activeGun = 1;

		gunImage = GameObject.Find("GunImage");
		uziImage = GameObject.Find("UziImage");
		bombImage = GameObject.Find("C4Image");
		rifleImage = GameObject.Find("RifleImage");
		shotgunImage = GameObject.Find("ShotgunImage");

		activeWeapons();
	}
	
	// Update is called once per frame
	void Update () {
		activeWeapons();
	}

	public void activeWeapons(){
		switch (activeGun) {
		case 1:
			gunImage.SetActive (true);
			uziImage.SetActive (false);
			bombImage.SetActive (false);
			rifleImage.SetActive (false);
			shotgunImage.SetActive (false);
			break;
		case 2:
			gunImage.SetActive (false);
			uziImage.SetActive (true);
			bombImage.SetActive (false);
			rifleImage.SetActive (false);
			shotgunImage.SetActive (false);
			break;
		case 3:
			gunImage.SetActive (false);
			uziImage.SetActive (false);
			bombImage.SetActive (true);
			rifleImage.SetActive (false);
			shotgunImage.SetActive (false);
			break;
		case 4:
			gunImage.SetActive (false);
			uziImage.SetActive (false);
			bombImage.SetActive (false);
			rifleImage.SetActive (true);
			shotgunImage.SetActive (false);
			break;
		case 5:
			gunImage.SetActive (false);
			uziImage.SetActive (false);
			bombImage.SetActive (false);
			rifleImage.SetActive (false);
			shotgunImage.SetActive (true);
			break;
		}
	}
}
