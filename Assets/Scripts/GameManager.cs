using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;
    private Camera cam;
    public List<Player> players= new List<Player>();

    public bool hasTurn=false;
    Vector3 spawnPos;
    private void Awake() 
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance=this;
    }
    public void SpawnPlayer(Player _player)
    {
        spawnPos=new Vector3(players.Count*5,1.5f,0);
        GameObject go=PhotonNetwork.Instantiate(_player.name,spawnPos,Quaternion.identity);
        players.Add(go.GetComponent<Player>());
    }

    public void GetTurn()
    {
        hasTurn=!hasTurn;
    }

}
