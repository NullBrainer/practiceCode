using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    // Use this for initialization
    public float TimeToLive;
    public float Speed;
	void Start () {
        Destroy(gameObject, TimeToLive);       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(0, 0, Speed * Time.deltaTime);
    }

        
       
}
