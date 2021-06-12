using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ArrowController : MonoBehaviourPunCallbacks
{
    [SerializeField] float arrowForce;
    Rigidbody rg;
    bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        rg=GetComponent<Rigidbody>();
        rg.velocity = transform.forward * arrowForce;
        transform.rotation=Quaternion.LookRotation(rg.velocity);
    }
    private void Update() 
    {
        if(!isHit)
        {
            transform.rotation=Quaternion.LookRotation(rg.velocity);
        }
        else
        {

        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        isHit=true;
        rg.constraints=RigidbodyConstraints.FreezeAll;
        if(other.collider.CompareTag("RedSpot"))
        {   
            UpdateScore(5);
        }
        else if(other.collider.CompareTag("YellowSpot"))
        {
            UpdateScore(8);
        }
        else if(other.collider.CompareTag("GreenSpot"))
        {
            UpdateScore(10);
        }
    }

    private void UpdateScore(int _score)
    {
        if (photonView.IsMine)
        {

            UIManager.instance.SetYourScore(_score);
        }
    }
}
