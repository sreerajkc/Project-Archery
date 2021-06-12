using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float mouseSens=1,cameraSmooth=0.1f;
    float  horizontalRot,verticalRot;
    [SerializeField] Vector2 verticalRotRange;
    [SerializeField] Vector2 horizontalRotRange; 
    Camera cam;
    Vector2 mousePos;
    Vector3 newVerticalRot;
    PhotonView pv;
    private Vector3 newHorizontalRot;

    private void Start() 
    {
        cam=GetComponentInChildren<Camera>();
        pv=GetComponent<PhotonView>();
    }
    private void Update() 
    {
        if(pv.IsMine)
        {
            ProcessInput();
        }
    }

    private void ProcessInput()
    {   
        horizontalRot += Input.GetAxisRaw("Mouse X") * mouseSens;
        verticalRot += Input.GetAxisRaw("Mouse Y") * mouseSens;

        horizontalRot = Mathf.Clamp(horizontalRot,horizontalRotRange.x,horizontalRotRange.y);
        verticalRot = Mathf.Clamp(verticalRot,verticalRotRange.x,verticalRotRange.y);

        newVerticalRot = new Vector3(-verticalRot,horizontalRot,0);
        cam.transform.localRotation=Quaternion.Lerp(cam.transform.rotation,Quaternion.Euler(newVerticalRot),.01f);
    }
}
