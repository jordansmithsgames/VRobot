using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public Transform spawnpoint1, spawnpoint2, spawnpoint3, controlRoom;
    public GameObject xrRig, xrCameras, flyCam;
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Photon.Realtime.Player[] others = PhotonNetwork.PlayerListOthers;

        if (others.Length == 0) // Player 1 / Host (no other players)
        {
            Debug.Log("Player 1 joined!");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnpoint1.position, spawnpoint1.rotation);
        }
        else if (others.Length == 1) // Player 2
        {
            Debug.Log("Player 2 joined!");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", spawnpoint2.position, spawnpoint2.rotation);
        }
        else // Player 3+
        {
            Debug.Log("Player 3 joined! (Camera man!)");
            xrCameras.SetActive(false);
            flyCam.SetActive(true);
            //spawnedPlayerPrefab = PhotonNetwork.Instantiate("Camera Player", spawnpoint3.position, spawnpoint3.rotation);
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