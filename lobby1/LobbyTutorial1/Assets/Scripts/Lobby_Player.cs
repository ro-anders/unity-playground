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

    public void onClickJoin() {
        SendReadyToBeginMessage();
    }

    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();
        ParentPref = GameObject.FindGameObjectWithTag("ParentPref");
        gameObject.transform.SetParent(ParentPref.transform);
        Setup();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (isLocalPlayer) {
            Setup();
        } else {
            SetupOtherPlayer();
        }
    }

    private void Setup()
    {
        MyText.text = "MYPlayer";
        Joinbutton.enabled = true;
        ButtonText.text = "JOIN";
    }
 
    private void SetupOtherPlayer()
    {
        MyText.text = "Not me";
        Joinbutton.enabled = false;
        ButtonText.text = "...";
    }

}
