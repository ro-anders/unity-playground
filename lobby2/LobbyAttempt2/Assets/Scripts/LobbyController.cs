using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour {

    private const string LOBBY_MATCH_NAME = "h2h-default";

    private NetworkManager lobbyManager;

    private bool isHost = false;

    public void OnStartPressed() {
        Debug.Log("Start pressed");
        lobbyManager = this.GetComponent<NetworkManager>();
        if (lobbyManager.matchMaker == null)
        {
            lobbyManager.StartMatchMaker();
        }
        lobbyManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, onMatchList);
    }

    private void onMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        if (!success)
        {
            Debug.Log("Error looking for default Lobby match.");
            // we are going to refresh it again
        }
        else
        {
            MatchInfoSnapshot found = null;
            if (matchList.Count > 0) {
                // There should be only one match ever - the default one
                // but we check just in case
                foreach (MatchInfoSnapshot match in matchList)
                {
                    if (match.name == LOBBY_MATCH_NAME)
                    {
                        found = match;
                        break;
                    }
                }
            }
            if (found == null)
            {
                // No one has hosted yet.  Try to host.
                lobbyManager.matchMaker.CreateMatch(LOBBY_MATCH_NAME, (uint)100, true,
                                    "", "", "", 0, 0, lobbyManager.OnMatchCreate);
                isHost = true;
            }
            else
            {
                lobbyManager.matchMaker.JoinMatch(found.networkId, "", "", "", 0, 0, lobbyManager.OnMatchJoined);
            }
        }
    }

    public void OnPlayPressed() {
        if (isHost) {
            NetworkManager.singleton.StopHost();
        } else {
            NetworkManager.singleton.StopClient();
        }
        SceneManager.LoadScene("Game");
    }
}
