using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;

public class LockYouOut : MonoBehaviour {

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;

	public GameObject textHits;
	public GameObject textPwd;

	public GameObject pwdCanvas;
	public GameObject hitsCanvas;

	public GameObject timerText;

	public bool timerOn = false;

	public GameObject myInput;
	public string myPasscode = "123321";
	public float timer = 0;

	//public File myFile;

	public List<int> myPwd = new List<int>();
	public List<int> myHits = new List<int>();
	// Use this for initialization
	void Start () {
		//StreamReader theReader = new StreamReader(
		//myFile
		//Debug.Log ("Hi friend");

		//TextAsset mydata = (TextAsset)Resources.LoadAssetAtPath("Assets/OtterDJ/Assets/Resources/Settings/touchCombo.txt", typeof(TextAsset));
		//Debug.Log (mydata.ToString ());
		//Char[] holderCombo = mydata.text.ToCharArray ();
		//Debug.Log (holderCombo.ToString ());
		//foreach(char a in holderCombo)
			//myPwd.Add (Convert.ToInt32( a - 48));

		myPwd.Add (1);
		myPwd.Add (2);
		myPwd.Add (3);
		myPwd.Add (4);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			timerText.GetComponent<Text> ().text = timer.ToString ();
		}
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

		if(textHits.GetComponent<Text>().text.Equals(textPwd.GetComponent<Text>().text) && !timerOn){
			//Application.LoadLevel("Settings");
			pwdCanvas.SetActive(true);
			hitsCanvas.SetActive(false);
			//passCodeEntered();
			if(!timerOn){
				timerOn = true;
				timer = 10;
			}
		}

		if (timer < 0 && timerOn) {
			//textHits.GetComponent<Text>().text = "";
			myHits.Clear();
			pwdCanvas.SetActive(false);
			hitsCanvas.SetActive(true);
			myInput.GetComponent<Text> ().text = "";
			timerOn = false;
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

	public IEnumerator passCodeEntered(){
		while (!myInput.GetComponent<Text> ().text.Equals (myPasscode)) {
			yield return new WaitForSeconds(5);
			pwdCanvas.SetActive(false);
			hitsCanvas.SetActive(true);
			myInput.GetComponent<Text> ().text = "";
		}
	}


}
