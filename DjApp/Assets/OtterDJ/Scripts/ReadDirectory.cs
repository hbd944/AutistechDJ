using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ReadDirectory : MonoBehaviour {

	public List<string> SongFiles = new List<string>();

	public string CurrFile;
	public string CurrDir;

	// Use this for initialization
	void Start () {
		CurrDir = new DirectoryInfo(Directory.GetCurrentDirectory());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
