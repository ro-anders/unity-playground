using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lobby_Player : NetworkLobbyPlayer {

    public GameObject ParentPref;
    public Button Joinbutton;
    public Text MyText;
    public Text ButtonText;

    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();
        ParentPref = GameObject.FindGameObjectWithTag("ParentPref");
        gameObject.transform.SetParent(ParentPref.transform);
        Setup();
    }

    private void Setup() {
        if (isLocalPlayer) {
            MyText.text = "MYPlayer";
            Joinbutton.enabled = true;
            ButtonText.text = "JOIN";
        } else {
            MyText.text = "Not me";
            Joinbutton.enabled = false;
            ButtonText.text = "...";
        }
    }
}
