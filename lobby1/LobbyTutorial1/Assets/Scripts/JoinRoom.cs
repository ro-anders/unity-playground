using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class JoinRoom : MonoBehaviour {

    public GameObject PrefabForHost;
    public GameObject ParentForHost;    

    LobbyManager lobbymanager;

	// Use this for initialization
	void Start () {
        lobbymanager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
	}

    public void RefreshList() {
        if (lobbymanager == null) {
            lobbymanager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
        }
        if (lobbymanager.matchMaker == null) {
            lobbymanager.StartMatchMaker();
        }
        lobbymanager.matchMaker.ListMatches(0, 20, "", true, 0, 0, onMatchList);
    }

    private void onMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList) {
        if (!success) {
            Debug.Log("Refresh failed.  Refresh again.");
            // we are going to refresh it again
        } else {
            foreach(MatchInfoSnapshot match in matchList) {
                GameObject ListGO = Instantiate(PrefabForHost);
                ListGO.transform.SetParent(ParentForHost.transform);
            }
        }
    }
}
