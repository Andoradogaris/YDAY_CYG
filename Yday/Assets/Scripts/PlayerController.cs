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

    [SerializeField]
    List<GameObject> weapons = new List<GameObject>();
    [SerializeField]
    int weaponIndex;
    Gun gun;
    AK ak;



    void Start()
    {
        charac = GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gun = weapons[1].GetComponent<Gun>();
        ak = weapons[0].GetComponent<AK>();
    }


    void Update()
    {
        if (!gameManager.isDead)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                gameManager.isRunning = true;
            }
            else
            {
                gameManager.isRunning = false;
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                gameManager.isCrouching = true;
            }
            else
            {
                gameManager.isCrouching = false;
            }


            SetSpeed();

            if (charac.isGrounded)
            {
                moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveD = transform.TransformDirection(moveD);
                moveD *= actualSpeed;

                if (Input.GetButton("Jump"))
                {
                    moveD.y = jumpSpeed;
                }
            }
            moveD.y -= gravity * Time.deltaTime;
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * actualSpeed * mouseSensitivity * 10);

            float rotationX = 0f;
            rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * actualSpeed * mouseSensitivity * 10;

            cam.transform.Rotate(Vector3.left * rotationX);

            charac.Move(moveD * Time.deltaTime * actualSpeed);

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                weaponIndex = 1;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                weaponIndex = 0;
            }

            SetWeapon(weaponIndex);
        }
    }

    void SetWeapon(int index)
    {
        if(index == 1)
        {
            weapons[index].SetActive(true);
            weapons[index - 1].SetActive(false);
            gameManager.UpdateAmmo(weapons[index].GetComponent<Gun>().actualAmmoInLoader, weapons[index].GetComponent<Gun>().totalAmmo);
        }
        else if(index == 0)
        {
            weapons[index].SetActive(true);
            weapons[index + 1].SetActive(false);
            gameManager.UpdateAmmo(weapons[index].GetComponent<AK>().actualAmmoInLoader, weapons[index].GetComponent<AK>().totalAmmo);
        }
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
    