using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject arrow;

    [SerializeField] Transform arrowSpawnPos;
    public int id;
    PhotonView pv;

    private void Start() 
    {   
        pv=GetComponent<PhotonView>();
        cam=GetComponentInChildren<Camera>();
        if(pv.IsMine)
        {
            GetComponent<MeshRenderer>().material.color=Color.blue;
        }
        else
        {

            cam.GetComponent<Camera>().enabled=false;
        }

    }
    private void Update() 
    {
        if(pv.IsMine)
        {
            if(Input.GetMouseButtonUp(0))
            {

                PhotonNetwork.Instantiate(arrow.name,arrowSpawnPos.position,arrowSpawnPos.rotation);
            }
        }

    }
  
}
