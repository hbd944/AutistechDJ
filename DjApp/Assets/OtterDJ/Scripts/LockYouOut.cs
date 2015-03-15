using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LockYouOut : MonoBehaviour {

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;

	public GameObject textHits;
	public GameObject textPwd;

	public GameObject pwdCanvas;
	public GameObject hitsCanvas;

	public GameObject myInput;
	public string myPasscode = "123321";

	public List<int> myPwd = new List<int>();
	public List<int> myHits = new List<int>();
	// Use this for initialization
	void Start () {
		myPwd.Add (1);
		myPwd.Add (2);
		myPwd.Add (3);
		myPwd.Add (4);
	}
	
	// Update is called once per frame
	void Update () {
		string staging = "";
		foreach (int a in myHits) {
			staging += a + ",";
		}
		textHits.GetComponent<Text>().text = staging;
		staging = "";
		foreach (int a in myPwd) {
			staging += a + ",";
		}
		textPwd.GetComponent<Text>().text = staging;

		if(textHits.GetComponent<Text>().text.Equals(textPwd.GetComponent<Text>().text)){
			//Application.LoadLevel("Settings");
			pwdCanvas.SetActive(true);
			hitsCanvas.SetActive(false);
		}

		if (myInput.GetComponent<Text> ().text.Equals (myPasscode)) {
			Application.LoadLevel("Settings");
		}
	}

	public void button1Pressed(){
		if (myHits.Count < myPwd.Count) {
			myHits.Add (1);
		} else {
			myHits.RemoveAt(0);
			myHits.Add (1);
		}
	}

	public void button2Pressed(){
		if (myHits.Count < myPwd.Count) {
			myHits.Add (2);
		} else {
			myHits.RemoveAt(0);
			myHits.Add (2);
		}
	}

	public void button3Pressed(){
		if (myHits.Count < myPwd.Count) {
			myHits.Add (3);
		} else {
			myHits.RemoveAt(0);
			myHits.Add (3);
		}
	}

	public void button4Pressed(){
		if (myHits.Count < myPwd.Count) {
			myHits.Add (4);
		} else {
			myHits.RemoveAt(0);
			myHits.Add (4);
		}
	}

	public void passCodeEntered(){

	}


}
