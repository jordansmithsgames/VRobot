﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public Transform spawnpoint1, spawnpoint2, controlRoom;
    public GameObject xrRig;
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
    
        if (PhotonNetwork.IsMasterClient) // Player 1
        {
            Debug.Log("Player 1 joined!");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnpoint1.position, spawnpoint1.rotation);
        }
        else // Player 2
        {
            Debug.Log("Player 2 joined!");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnpoint2.position, spawnpoint2.rotation);
        }

        spawnedPlayerPrefab.transform.parent = controlRoom;
        xrRig.transform.position = spawnedPlayerPrefab.transform.position;
        xrRig.transform.rotation = spawnedPlayerPrefab.transform.rotation;
    }

    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Network Player");
        foreach(GameObject player in players) player.transform.parent = controlRoom;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}