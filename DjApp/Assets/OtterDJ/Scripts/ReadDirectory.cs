using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class ReadDirectory : MonoBehaviour {

	public List<string> SongFiles = new List<string>();

	public string CurrFile;
	public string CurrDir;
	public DirectoryInfo DirInfo;

	public GameObject textObject;
	// Use this for initialization
	void Start () {
		DirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
//		SongFiles = DirInfo.GetFiles();
		//foreach File in 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClick() {
		// CurrDir;

		textObject.GetComponent<Text>().text = SongFiles[0].ToString();
	}
}
