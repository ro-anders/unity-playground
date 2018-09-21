using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager {

    public GameObject Lobby;

    private void Start()
    {
        Lobby.SetActive(false);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        print("A game has created");
        Lobby.SetActive(true);
    }
}
