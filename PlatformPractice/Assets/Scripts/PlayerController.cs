using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float PlayerSpeed = 10f;
    public float JumpForce = 10f;
    public Rigidbody RB;
    public float DistanceFromGround = 2.5f;
    private Camera playerCam;
    [HideInInspector]
    public bool grounded = true;

    public int mouseSensitivity;
    private float HorizonalAxis;
    private float VerticalAxis;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        playerCam = GetComponentInChildren<Camera>();
    }
    // Update is called once per frame
   
    void Update()
    {
        checkJumpState();
        changeCameraRotation();
    }

 #region[Movment]
    void FixedUpdate()
    {
        checkInputs();
       
        
    }

    private void checkJumpState()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        if (!grounded)
        {
            if (Physics.Raycast(landingRay, out hit, DistanceFromGround))  //third variable is required height to use  
            {
                grounded = hit.distance <= DistanceFromGround;
            }
            Debug.Log(grounded + ": " + hit.distance + " landingRay Origin: " + landingRay.origin);
        }
    }

    private void checkInputs()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveHorizontal(PlayerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveHorizontal(-PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveVertical(PlayerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveVertical(-PlayerSpeed * Time.deltaTime);
        }
        if (grounded == true && Input.GetKey(KeyCode.Space))
        {
            RB.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void MoveHorizontal(float axis)
    {
        transform.Translate(axis, 0f, 0f);
    }

    private void MoveVertical(float axis)
    {
        transform.Translate(0f, 0f, axis);
    }

    #endregion


    private void changeCameraRotation()
    {
        HorizonalAxis = Input.GetAxisRaw("Mouse X");
        VerticalAxis = Input.GetAxisRaw("Mouse Y") * -1;//to prevent inverted movement
        Vector3 camRotation = playerCam.transform.localEulerAngles;
        Vector3 horizontalRotation = transform.localEulerAngles;
        camRotation.x += VerticalAxis * mouseSensitivity;
        horizontalRotation.y += HorizonalAxis * mouseSensitivity;

        transform.localEulerAngles = horizontalRotation;
        playerCam.transform.localEulerAngles = camRotation;
    }

}
