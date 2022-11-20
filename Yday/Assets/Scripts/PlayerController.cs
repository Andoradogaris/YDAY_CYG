using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float normalSpeed = 6f;

    public float actualSpeed = 6f;

    [SerializeField]
    private float jumpSpeed = 8f;

    [SerializeField]
    private float gravity = 20f;

    //[HideInInspector]
    public float mouseSensitivity;

    public Vector3 moveD = Vector3.zero;

    CharacterController charac;
    GameManager gameManager;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    float minCam;
    [SerializeField]
    float maxCam;



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
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * actualSpeed * mouseSensitivity * 10);

        float rotationX = 0f;
        rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * actualSpeed * mouseSensitivity * 10;
        rotationX = Mathf.Clamp(rotationX, minCam, maxCam);

        cam.transform.Rotate(Vector3.left * rotationX);

        charac.Move(moveD * Time.deltaTime * actualSpeed);
    }

    void SetSpeed()
    {
        if(gameManager.isCrouching)
        {
            actualSpeed = normalSpeed / 1.5f;
        }
        else if(gameManager.isRunning &&  gameManager.canRun)
        {
            actualSpeed = normalSpeed * 1.5f;
        }
        else
        {
            actualSpeed = normalSpeed;
        }
    }
}
    