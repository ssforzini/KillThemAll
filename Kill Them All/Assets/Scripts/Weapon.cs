﻿using UnityEngine;

public enum fType
{
    single,floor,multiple,fire,ball
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

}