using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float speed = 5;

	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) {
            return;
        }
        var inputs = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * Time.deltaTime * inputs * speed);
	}
}
