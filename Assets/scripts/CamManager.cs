using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{
    public Transform target;
    public float cameraDist = 10f;
    public float cameraHei = 5f;

    CinemachineVirtualCamera vcam;


    // Start is called before the first frame update
    void Start()
    {
        //getting a reference to the virtual camera
        vcam = GetComponent<CinemachineVirtualCamera>();

        //set the virtual camera's follow and lookat targets to the their transfrom component
        vcam.Follow = target;
        vcam.LookAt = target;

        //Set the initial position of the virtual cam
        vcam.transform.position = new Vector3(target.position.x, target.position.y + cameraHei, target.position.z - cameraDist);
    }

    //using the late update function rather than update as it can reduce the amount of stuttering or jitteriness that may occurr
    //with the camera movement as it waits till the movement of the player is done then updates  
    void FixedUpdate() 
    {
        //update the position of the cam after the movement of the player
        vcam.transform.position = new Vector3(target.position.x, target.position.y + cameraHei, target.position.z - cameraDist);
    }

    
}
