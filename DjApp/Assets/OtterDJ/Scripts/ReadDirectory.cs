using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System;

public class ReadDirectory : MonoBehaviour {

	public List<string> SongFiles = new List<string>();

	public string CurrFile;
	public string CurrDir;
	public DirectoryInfo DirInfo;
	public DirectoryInfo[] DirInfos;
	public FileInfo[] FlInfo;
	//public FileInfo file1;
	public int currNum = 0;

	public GameObject textObject;
	// Use this for initialization
	void Start () {
		DirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
		DirInfos = DirInfo.GetDirectories();
		 
		//SongFiles = DirInfo.GetFiles();
		//for file finding within folder


		FlInfo = DirInfo.GetFiles();
		textObject.GetComponent<Text> ().text = Directory.GetCurrentDirectory().ToString();
		if(FlInfo != null)
		{
			foreach(FileInfo file1 in FlInfo) {
				SongFiles.Add(file1.ToString());
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClick() {
		// CurrDir;
		/*if (currNum < DirInfos.Length) {
			textObject.GetComponent<Text> ().text = DirInfos [currNum].Name;
			currNum++;
		} else {
			currNum = 0;
			textObject.GetComponent<Text> ().text = DirInfos [currNum].Name;
			currNum++;
		}*/
			
		 // Use this to iterate through all files in list
		if (currNum < SongFiles.Count) {
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			currNum++;
		} else {
			currNum = 0;
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			currNum++;
		}
	}
}