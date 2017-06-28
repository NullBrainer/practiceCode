using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour {

    // Use this for initialization
    public float fireRate = 0.25f;
    public GameObject projectile;

    private Camera fpsCamera;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;
    public Transform gunEnd;
    public float weaponRange = 50f;

    void Start () {
        fpsCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;



            if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, weaponRange))
            {

            }
            else
            {

            }
        }
	}

    private IEnumerator ShotEffect()
    {
        yield return shotDuration;
    }
}
