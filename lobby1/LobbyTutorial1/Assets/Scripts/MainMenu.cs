using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public InputField MatchNameInput;
    public LobbyManager lobbymanager;


    public void OnClickHostButton() {
        lobbymanager.StartMatchMaker();
        lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true,
                                            "", "", "", 0, 0, lobbymanager.OnMatchCreate);

    }

    public void OnClickJoinButton() {
        lobbymanager.StartMatchMaker();
    }
}
