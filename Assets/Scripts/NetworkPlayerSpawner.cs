using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public Transform spawnpoint1, spawnpoint2;
    public GameObject xrRig;
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        // Player 1
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Player 1 joined!");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnpoint1.position, spawnpoint1.rotation);
            xrRig.transform.position = spawnedPlayerPrefab.transform.position;
            xrRig.transform.rotation = spawnedPlayerPrefab.transform.rotation;
        }

        // Player 2
        else
        {
            Debug.Log("Player 2 joined!");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnpoint2.position, spawnpoint2.rotation);
            xrRig.transform.position = spawnedPlayerPrefab.transform.position;
            xrRig.transform.rotation = spawnedPlayerPrefab.transform.rotation;
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}