using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class HostSetup : MonoBehaviour
{

    public Text HostName;

    MatchInfoSnapshot match;
    LobbyManager lobbymanager;
    GameObject LobbyParent;

    public void Start()
    {
        lobbymanager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
        LobbyParent = GameObject.FindGameObjectWithTag("LOBBYPARENT");
    }

    public void Setup(MatchInfoSnapshot inMatch)
    {
        match = inMatch;
        HostName.text = match.name;
    }

    public void Join()
    {
        if (lobbymanager == null) {
            lobbymanager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
        }

        //LobbyParent.SetActive(true);
        var go = LobbyParent.GetComponentsInChildren<Transform>(true);
        foreach(var item in go) {
            item.gameObject.SetActive(true);
        }

        lobbymanager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, lobbymanager.OnMatchJoined);
    }

}
