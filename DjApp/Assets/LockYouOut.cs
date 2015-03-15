using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockYouOut : MonoBehaviour {

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Menu)) {
			button1.GetComponent<Text>().text = "Menu button";
		} else if (Input.GetKey (KeyCode.Home) || Input.GetKeyUp (KeyCode.Home) || Input.GetKeyDown (KeyCode.Home)) {
			button1.GetComponent<Text>().text = "Home button";
		} else if (Input.GetKey (KeyCode.Escape) || Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Escape) ) {
			button1.GetComponent<Text>().text = "Back button";
		} else {
			button4.GetComponent<Text>().text = "REKT";
			Application.Quit();
		}
	}
}
