using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float PlayerSpeed = 10f;
    public float JumpForce = 10f;
    public Rigidbody RB;
    public float DistanceFromGround = 2.5f;
    public Input[] controllers;
    [HideInInspector]
    public bool grounded = true;
    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame

    void Update()
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

    void FixedUpdate()
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
}
