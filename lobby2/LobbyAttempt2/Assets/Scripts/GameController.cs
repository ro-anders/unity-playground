using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    private const string GAME_MATCH_NAME = "h2h-2";

    private NetworkManager lobbyManager;

    public void Start()
    {
        ConnectToDefault();
    }

    public void ConnectToDefault()
    {
        Debug.Log("Connecting to game");
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
            if (matchList.Count > 0)
            {
                // There should be only one match ever - the default one
                // but we check just in case
                foreach (MatchInfoSnapshot match in matchList)
                {
                    if (match.name == GAME_MATCH_NAME)
                    {
                        found = match;
                        break;
                    }
                }
            }
            if (found == null)
            {
                // No one has hosted yet.  Try to host.
                lobbyManager.matchMaker.CreateMatch(GAME_MATCH_NAME, (uint)100, true,
                                    "", "", "", 0, 0, lobbyManager.OnMatchCreate);
            }
            else
            {
                lobbyManager.matchMaker.JoinMatch(found.networkId, "", "", "", 0, 0, lobbyManager.OnMatchJoined);
            }
        }
    }

}
