using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class HostSetup : MonoBehaviour
{

    public Text HostName;

    MatchInfoSnapshot match;

    public void Setup(MatchInfoSnapshot inMatch)
    {
        match = inMatch;
        HostName.text = match.name;
    }
}
