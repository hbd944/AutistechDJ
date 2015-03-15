using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;

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
	public WWW songToPlay;
	public AudioSource sourcerino;
	public AudioClip cliperino;

	// Use this for initialization
	void Start () {
		DirInfo = new DirectoryInfo("/mnt/sdcard/media/");
		//DirInfo.MoveTo ("");
		//DirInfo.MoveTo("mnt"); 
		//DirInfo.MoveTo("sdcard");
		//DirInfo.MoveTo("media");
		DirInfos = DirInfo.GetDirectories();
		 
		//SongFiles = DirInfo.GetFiles();
		//for file finding within folder


		FlInfo = DirInfo.GetFiles();
		//textObject.GetComponent<Text> ().text = Application.dataPath;
		if(FlInfo != null)
		{
			foreach(FileInfo file1 in FlInfo) {
					SongFiles.Add(file1.ToString());
			}
		}


		//sourcerino.Play ();
		//sourcerino.GetComponent<AudioClip>().LoadAudioData(true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator onClick() {
		// CurrDir;
		/*if (currNum < DirInfos.Length) {
			textObject.GetComponent<Text> ().text = DirInfos [currNum].Name;
			currNum++;
		} else {
			currNum = 0;
			textObject.GetComponent<Text> ().text = DirInfos [currNum].Name;
			currNum++;
		}

		textObject.GetComponent<Text> ().text = "Playing!";
		sourcerino.Play();
		if(!sourcerino.isPlaying)
			textObject.GetComponent<Text> ().text = "FAILED";*/
			
		textObject.GetComponent<Text> ().text = SongFiles [currNum];
		songToPlay = new WWW ("file:///" + SongFiles [currNum]);
		cliperino = songToPlay.GetAudioClip (false, true);
		textObject.GetComponent<Text> ().text = cliperino.loadState.ToString ();
		while (cliperino.loadState.ToString().Equals("Unloaded")){
			yield return new WaitForSeconds(5);
		}
		textObject.GetComponent<Text> ().text = cliperino.loadState.ToString ();
		sourcerino.clip = cliperino;
		 // Use this to iterate through all files in list
		if (currNum < SongFiles.Count) {
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			currNum++;
		} else {
			currNum = 0;
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			currNum++;
		}
		sourcerino.Play();
	}
}