using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnAnyKey : MonoBehaviour {

	public Button mahButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey || Input.anyKeyDown) {
			mahButton.GetComponent<Text>().text = "FUCK YOU ASSCLOWN";
		}
	}
}
