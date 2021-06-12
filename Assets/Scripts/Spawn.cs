using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Spawn : MonoBehaviourPunCallbacks
{
    public int myScore=0;
    public int oppositeScore=0;
    public static Spawn instance;
    public UIManager UImanager;
    public Vector3[] spawnpos; 
    public Player player;
    public GameObject archeryBoard;
    private Vector3 playerSpawnPos;
    private Vector3 boardSpawnPos;

    public int boardDistance;
    bool alreadySpawn;
    public bool hasTurn=false;

    private void Awake() 
    {
        if(instance)
        {
            Destroy(this);
            return;
        }
        instance=this;
    }
    private void Start() 
    {
        SetSpawnPos();
        PhotonNetwork.Instantiate(player.name,playerSpawnPos,Quaternion.identity);
        PhotonNetwork.Instantiate(archeryBoard.name,boardSpawnPos,Quaternion.identity);
    }
    void SetSpawnPos()
    {
        Photon.Realtime.Player[] player= PhotonNetwork.PlayerList;
        for(int i=0;i < player.Length; i++)
        {
            photonView.RPC("RPC_Spawn",player[i],spawnpos[i]);
        }
    }
    [PunRPC]
    void RPC_Spawn(Vector3 _spawnpos)
    {
        playerSpawnPos =_spawnpos;
        boardSpawnPos = new Vector3(_spawnpos.x,_spawnpos.y,_spawnpos.z + boardDistance);
    }
        public void GetTurn()
    {
        hasTurn=!hasTurn;
    }

}
