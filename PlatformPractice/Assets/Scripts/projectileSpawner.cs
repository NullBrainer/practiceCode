using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour {

    // Use this for initialization
    public float fireRate = 0.25f;
    public GameObject projectile;

    //private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;
    public Transform gunEnd;
    public float weaponRange = 50f;

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       
	}

   
}
