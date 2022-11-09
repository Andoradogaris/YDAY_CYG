using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float normalSpeed = 6f;

    [SerializeField]
    private float actualSpeed = 6f;

    [SerializeField]
    private float jumpSpeed = 8f;

    [SerializeField]
    private float gravity = 20f;

    //[HideInInspector]
    public float mouseSensitivity;

    private Vector3 moveD = Vector3.zero;

    CharacterController charac;

    [SerializeField]
    private bool isCrouching;
    [SerializeField]
    private bool isRunning;

    void Start()
    {
        charac = GetComponent<CharacterController>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }


        SetSpeed();

        if(charac.isGrounded)
        {
            moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= actualSpeed;

            if(Input.GetButton("Jump"))
            {
                moveD.y = jumpSpeed;
            }
        }
        moveD.y -= gravity * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * actualSpeed * mouseSensitivity);

        charac.Move(moveD * Time.deltaTime * actualSpeed);
    }

    void SetSpeed()
    {
        if(isCrouching)
        {
            actualSpeed = normalSpeed / 2;
        }
        else if(isRunning)
        {
            actualSpeed = normalSpeed * 2;
        }else
        {
            actualSpeed = normalSpeed;
        }
    }
}
    