using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;
using UnityEngine;

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

	// Use this for initialization
	void Start () {
		DirInfo = new DirectoryInfo("mnt/sdcard/media");
		//DirInfo.MoveTo ("");
		//DirInfo.MoveTo("mnt"); 
		//DirInfo.MoveTo("sdcard");
		//DirInfo.MoveTo("media");
		DirInfos = DirInfo.GetDirectories();
		 
		//SongFiles = DirInfo.GetFiles();
		//for file finding within folder


		FlInfo = DirInfo.GetFiles();
		textObject.GetComponent<Text> ().text = Application.dataPath;
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

		textObject.GetComponent<Text> ().text = SongFiles [currNum];
		songToPlay = new WWW("https://www.youtube.com/watch?v=gcejLp72iCE");
		sourcerino.clip = songToPlay.GetAudioClip(false, true, AudioType.MPEG);
		//sourcerino.GetComponent<AudioClip>().LoadAudioData(true);
		textObject.GetComponent<Text> ().text = sourcerino.volume.ToString();
		sourcerino.Play();
		if(!sourcerino.isPlaying)
			textObject.GetComponent<Text> ().text = sourcerino.clip.length.ToString();
			
		 // Use this to iterate through all files in list
		if (currNum < SongFiles.Count) {
			/*textObject.GetComponent<Text> ().text = SongFiles [currNum];
			if(!sourcerino.isPlaying)
			{
				songToPlay = new WWW("file:///" + SongFiles[currNum]);
				sourcerino.clip = songToPlay.GetAudioClip(false, false);
				sourcerino.Play();
			}else {
				sourcerino.Stop();
				songToPlay = new WWW("file:///" + SongFiles[currNum]);
				sourcerino.clip = songToPlay.GetAudioClip(false, false);
				sourcerino.Play ();
			}
			currNum++;*/
		} else {
			/*currNum = 0;
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			if(!sourcerino.isPlaying)
			{
				songToPlay = new WWW("file:///" + SongFiles[currNum]);
				sourcerino.clip = songToPlay.GetAudioClip(false, false);
				sourcerino.Play();
			}else {
				sourcerino.Stop();
				songToPlay = new WWW("file:///" + SongFiles[currNum]);
				sourcerino.clip = songToPlay.GetAudioClip(false, false);
				sourcerino.Play ();
			}
			currNum++;*/
		}
	}
}