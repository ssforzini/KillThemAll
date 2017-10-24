using UnityEngine;

public class WeaponManager : MonoBehaviour {
	private int activeWeapon = 0;
	public GameObject[] weapons;
	private Weapon[] wpScrip = {null,null,null};
	private float uziFire;
	private float gunFire;

	public GameObject bullet;
	public Transform puntoSalida;

	void Start(){
		for(int i = 0; i < weapons.Length; i++){
			wpScrip [i] = weapons [i].gameObject.GetComponent<Weapon> ();
		}
	}

	void Update(){
		uziFire -= Time.deltaTime;
		gunFire -= Time.deltaTime;
	}

	public void fire(){
		if (Input.GetButtonDown("Fire")) {
			//if(wpScrip[activeWeapon].type.ToString() == "single"){
				Instantiate(bullet, puntoSalida.position, puntoSalida.rotation);
			//}
		}
	}

	void OnTriggerEnter(Collider col) {

		if(col.gameObject.tag == "Weapon"){
			activeWeapon = col.gameObject.GetComponent<WeaponGrab> ().getWType ();
			changeWeaponPrefab ();
			changeWeaponStats ();
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

	public void changeWeaponStats(){
		
	}
}
