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
    GameManager gameManager;



    void Start()
    {
        charac = GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            gameManager.isRunning = true;
        }
        else
        {
            gameManager.isRunning = false;
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            gameManager.isCrouching = true;
        }
        else
        {
            gameManager.isCrouching = false;
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
        if(gameManager.isCrouching)
        {
            actualSpeed = normalSpeed / 2;
        }
        else if(gameManager.isRunning &&  gameManager.canRun)
        {
            actualSpeed = normalSpeed * 2;
        }else
        {
            actualSpeed = normalSpeed;
        }
    }
}
    