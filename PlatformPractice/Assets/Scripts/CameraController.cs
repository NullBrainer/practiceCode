using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //private Vector3 offset;

    public GameObject Player;
    float HorizonalAxis;
    float VerticalAxis;
    private Vector3 changingYVector;
    private Vector3 changingXVector;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //offSetValue = player.transform.localScale.y + 2f;
        //offSet = new Vector3(0, offSetValue);
        //cam.transform.position = offSet;

    }


    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = Player.transform.position+ new Vector3(0,Player.transform.localScale.y);

    }
    protected void Update()
    {//Dividing it by delta time increases speed
        HorizonalAxis = Input.GetAxisRaw("Mouse X");
        VerticalAxis = Input.GetAxisRaw("Mouse Y") * -1;// to prevent inverted movement
        changingYVector = new Vector3(VerticalAxis, 0, 0);
        changingXVector = new Vector3(0, HorizonalAxis, 0);
        transform.Rotate(changingYVector);
        Player.transform.Rotate(changingXVector);
    }
}
/*
 
 controller
    camera
        model    
 */
