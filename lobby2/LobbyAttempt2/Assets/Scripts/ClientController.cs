using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientController : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        Text thisText = this.GetComponent<Text>();
        NetworkIdentity id = this.GetComponent<NetworkIdentity>();
        thisText.text = "Client: " + id.netId;

        GameObject clientList = GameObject.FindGameObjectWithTag("ClientParent");
        gameObject.transform.SetParent(clientList.transform);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
