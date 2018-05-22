using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

    public InputField input;
    public Text output;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && (input.text != "")) {
            output.text += input.text + "\n";
            input.text = "";
        }
	}
}
