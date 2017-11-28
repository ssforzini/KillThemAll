using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {
	private int activeWeapon = 0;
	public GameObject[] weapons;
	private Weapon[] wpScrip = {null,null,null,null,null};
	private float weaponTime = 0;

	public GameObject bullet;
	public GameObject rifleBullet;
	public Transform puntoSalida;
	public Transform floorSalida;
	public Transform RifleSalida;

	public Transform[] ShotgunSalida;

	private int actualAmmo = 0;
	private bool isInfiniteAmmo = true;
	private float fireVelocity;
    private GameObject actualPrefab;

	private AudioSource sound;

	private ActualGunImages agi;

	[HideInInspector]
	public bool deadPlayer = false;
	private Text ammoText;

	void Start(){
		agi = GameObject.Find ("ActualGunImages").GetComponent<ActualGunImages>();
		ammoText = GameObject.Find ("Ammo").GetComponent<Text> ();
		updateAmmoText ();
		for(int i = 0; i < weapons.Length; i++){
			wpScrip [i] = weapons [i].gameObject.GetComponent<Weapon> ();
		}
		fireVelocity = wpScrip [activeWeapon].fireVelocity;
		sound = wpScrip [activeWeapon].sound;
		agi = GameObject.Find ("ActualGunImages").GetComponent<ActualGunImages> ();
	}

	void Update(){
		weaponTime -= Time.deltaTime;
		if(!deadPlayer){
			fire ();
		}
	}

	public void fire(){
        if (Input.GetButtonDown ("Fire")) {
			if((wpScrip[activeWeapon].type.ToString() == "single" && activeWeapon == 0) && weaponTime <= 0){
				sound.Play ();
				Instantiate (bullet, puntoSalida.position, puntoSalida.rotation);
				loseAmmo ();
                weaponTime = fireVelocity;
            }
			if ((wpScrip[activeWeapon].type.ToString() == "floor" && activeWeapon == 2) && weaponTime <= 0) {
                Instantiate(actualPrefab, floorSalida.position, floorSalida.rotation);
                weaponTime = fireVelocity;
                loseAmmo();
            }

			if ((wpScrip[activeWeapon].type.ToString() == "rifle" && activeWeapon == 3) && weaponTime <= 0) {
				sound.Play ();
				Instantiate(rifleBullet, RifleSalida.position, RifleSalida.rotation);
				weaponTime = fireVelocity;
				loseAmmo();
			}

			if((wpScrip[activeWeapon].type.ToString() == "multiple" && activeWeapon == 4) && weaponTime <= 0){
				sound.Play ();
				for(int i = 0; i < ShotgunSalida.Length; i++){
					Instantiate(bullet, ShotgunSalida[i].position, ShotgunSalida[i].rotation);
				}
				weaponTime = fireVelocity;
				loseAmmo();
			}
        } 

		if (Input.GetButton("Fire")) {
			if((wpScrip[activeWeapon].type.ToString() == "single" && activeWeapon == 1) && weaponTime <= 0){
				sound.Play ();
				Instantiate(bullet, puntoSalida.position, puntoSalida.rotation);
				loseAmmo ();
                weaponTime = fireVelocity;
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
			agi.activeGun = activeWeapon + 1;
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
        actualPrefab = wp.weaponPrefab;
		sound = wp.sound;

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
