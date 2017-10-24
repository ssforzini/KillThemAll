using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {
	private int activeWeapon = 0;
	public GameObject[] weapons;
	private Weapon[] wpScrip = {null,null,null};
	private float uziFire = 0;
	private float gunFire = 0;

	public GameObject bullet;
	public Transform puntoSalida;

	private int actualAmmo = 0;
	private bool isInfiniteAmmo = true;
	private float fireVelocity = 0.4f;

	private Text ammoText;

	void Start(){
		ammoText = GameObject.Find ("Ammo").GetComponent<Text> ();
		updateAmmoText ();
		for(int i = 0; i < weapons.Length; i++){
			wpScrip [i] = weapons [i].gameObject.GetComponent<Weapon> ();
		}
	}

	void Update(){
		uziFire -= Time.deltaTime;
		gunFire -= Time.deltaTime;
		fire ();
	}

	public void fire(){
		if (Input.GetButtonDown ("Fire")) {
			if((wpScrip[activeWeapon].type.ToString() == "single" && activeWeapon == 0) && gunFire <= 0){
				Instantiate (bullet, puntoSalida.position, puntoSalida.rotation);
				gunFire = fireVelocity;
				loseAmmo ();
			}
		} 

		if (Input.GetButton("Fire")) {
			if((wpScrip[activeWeapon].type.ToString() == "single" && activeWeapon == 1) && uziFire <= 0){
				Instantiate(bullet, puntoSalida.position, puntoSalida.rotation);
				uziFire = fireVelocity;
				loseAmmo ();
			}
		}
	}

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "Weapon"){
			activeWeapon = col.gameObject.GetComponent<WeaponGrab> ().getWType ();	
			changeWeaponStats (col.gameObject.GetComponent<Weapon> ());
			changeWeaponPrefab ();
			Destroy (col.gameObject);
		}

	}

	public void changeWeaponPrefab(){
		for(int i = 0; i < weapons.Length; i++){
			if (i == activeWeapon) {
				weapons [i].SetActive (true);
			} else {
				weapons [i].SetActive (false);
			}
		}
	}

	public void changeWeaponStats(Weapon wp){
		actualAmmo = wp.ammo;
		fireVelocity = wp.fireVelocity;
		if ((int)wp.infiniteAmmo == 0) {
			isInfiniteAmmo = true;
		} else {
			isInfiniteAmmo = false;
		}
		updateAmmoText ();
	}

	public void loseAmmo(){
		if(!isInfiniteAmmo){
			actualAmmo--;
			updateAmmoText ();
		}

		if(actualAmmo == 0){
			activeWeapon = 0;
			changeWeaponStats (wpScrip[0]);
			changeWeaponPrefab ();
		}
	}

	public void updateAmmoText(){
		if (!isInfiniteAmmo) {
			ammoText.text = "Ammo: " + actualAmmo;
		} else {
			ammoText.text = "Ammo: ∞";
		}
	}
}
