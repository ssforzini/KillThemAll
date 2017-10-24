using UnityEngine;

public enum wType
{
	gun,uzi,c4
}

public class WeaponGrab : MonoBehaviour {

	public wType type;
	private int wType;

	void Start(){
		wType = (int)type;
	}
	
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 80);
	}

	public int getWType(){
		return wType;
	}
}
