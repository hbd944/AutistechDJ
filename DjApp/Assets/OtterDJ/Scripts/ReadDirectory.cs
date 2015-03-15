using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;

public class ReadDirectory : MonoBehaviour {

	public List<string> SongFiles = new List<string>();
	public List<byte[]> mySongs = new List<byte[]> ();

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
	public FileStream myReader;

	// Use this for initialization
	IEnumerator Start () {
		DirInfo = new DirectoryInfo("/mnt/sdcard/media/");
		//DirInfo.MoveTo ("");
		//DirInfo.MoveTo("mnt"); 
		//DirInfo.MoveTo("sdcard");
		//DirInfo.MoveTo("media");
		DirInfos = DirInfo.GetDirectories();
		 
		//SongFiles = DirInfo.GetFiles();
		//for file finding within folder


		FlInfo = DirInfo.GetFiles();

		if(FlInfo != null)
		{
			foreach(FileInfo file1 in FlInfo) {
				myReader = file1.Open(FileMode.Open);
				byte[] b= new byte[9999];
				while(myReader.Read (b,0,b.Length) > 0)
				{
					mySongs.Add(b);
					//SongFiles.Add(Convert.ToBase64String(b));
					textObject.GetComponent<Text> ().text = Convert.ToBase64String(b).Substring(0,25);
				}
				//yield return new WaitForSeconds(1);
				yield return null;
				textObject.GetComponent<Text> ().text = file1.ToString();
				SongFiles.Add(file1.ToString());
			}
		}


		//sourcerino.Play ();
		//sourcerino.GetComponent<AudioClip>().LoadAudioData(true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClick() {
		// CurrDir;
		if (currNum < SongFiles.Count) {
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			currNum++;
		} else {
			currNum = 0;
			textObject.GetComponent<Text> ().text = SongFiles [currNum];
			currNum++;
		}
		textObject.GetComponent<Text> ().text = "Writing File!";
		System.IO.File.WriteAllBytes ("/mnt/sdard/media/" + SongFiles [currNum], mySongs [currNum]);
		textObject.GetComponent<Text> ().text = "/mnt/sdard/media/" + SongFiles [currNum] + " : done.";
		songToPlay = new WWW ("file://" + Application.absoluteURL + SongFiles [currNum]);
		cliperino = songToPlay.GetAudioClip (false, false);
		sourcerino.clip = cliperino;
		sourcerino.PlayDelayed (2);  
		/*

		textObject.GetComponent<Text> ().text = "Playing!";
		sourcerino.Play();
		if(!sourcerino.isPlaying)
			textObject.GetComponent<Text> ().text = "FAILED";
			
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
		sourcerino.Play();*/
	}
}