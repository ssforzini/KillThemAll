using UnityEngine;

public enum fType
{
    single,floor,multiple,fire,ball,rifle
}

public enum Active
{
    on, off
}

public class Weapon : MonoBehaviour {

    public int ammo;
    public Active infiniteAmmo;
    public float fireVelocity;
    public fType type;
    public Active fireActive;
    public GameObject weaponPrefab;
	[HideInInspector]
	public AudioSource sound;
    
	void Start(){
		if((int)type == 1){
			sound = GameObject.Find ("ExplosionSound").GetComponent<AudioSource> ();
		} else {
			sound = GameObject.Find ("FireSound").GetComponent<AudioSource> ();
		}

	}
}
