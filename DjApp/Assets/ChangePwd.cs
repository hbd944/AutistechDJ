using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChangePwd : MonoBehaviour {

	public List<int> myHits = new List<int>();
	public GameObject textHits;

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;

	// Use this for initialization
	void Start () {
		button1Pressed ();
	}
	
	// Update is called once per frame
	void Update () {
		string staging = "";
		foreach (int a in myHits) {
			staging += a + ",";
		}
		textHits.GetComponent<Text>().text = staging;
		//textHits.GetComponent<Text> ().text = "This should Work!" + Time.deltaTime;
	}


	public void button1Pressed(){
		myHits.Add (1);
		Debug.Log ("Button Pressed");
	}
	
	public void button2Pressed(){
		myHits.Add (2);
		Debug.Log ("Button Pressed");
	}
	
	public void button3Pressed(){
		myHits.Add (3);
		Debug.Log ("Button Pressed");
	}
	
	public void button4Pressed(){
		myHits.Add (4);
		Debug.Log ("Button Pressed");
	}
}
