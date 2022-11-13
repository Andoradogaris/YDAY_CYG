using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private bool isFPS = true;

    [SerializeField]
    private GameObject FPSVIEWER;
    [SerializeField]
    private GameObject TPSVIEWER;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            if (isFPS)
            {
                isFPS = false;
                transform.position = TPSVIEWER.transform.position;
                //transform.rotation = Quaternion.Euler(TPSVIEWER.transform.rotation.x, player.transform.rotation.y, TPSVIEWER.transform.rotation.z);
            }
            else
            {
                isFPS = true;
                transform.position = FPSVIEWER.transform.position;
                //transform.rotation = Quaternion.Euler(FPSVIEWER.transform.rotation.x, player.transform.rotation.y, FPSVIEWER.transform.rotation.z);
            }
        }
    }
}
