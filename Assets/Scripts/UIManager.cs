using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Photon.Pun;

public class UIManager : MonoBehaviourPunCallbacks
{
    public int scoreNo,opScoreNo;
    public static UIManager instance;
    [SerializeField] TextMeshProUGUI myScore,oppositeScore;

    private void Awake() 
    {   
        if(instance)
        {
            Destroy(this);
            return;
        }
        instance=this;
    }
    public void SetYourScore(int _score)
    {
        scoreNo+=_score;
        myScore.text=scoreNo.ToString();
        photonView.RPC("RPC_GetOpScore",RpcTarget.OthersBuffered,scoreNo);
        Debug.Log(scoreNo);

    }
    public void SetOppositeScore(int _score)
    {
        opScoreNo=_score;
        oppositeScore.text=opScoreNo.ToString();
        Debug.Log(opScoreNo);
    }
    [PunRPC]
    void RPC_GetOpScore(int _score)
    {
        SetOppositeScore(_score);
    }
}
