using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DJManager : MonoBehaviour 
{
	public List<Song> songs = new List<Song>();

	public int songIndex;

	public GameObject slot0;
	public GameObject slot1;
	public GameObject slot2;
	public GameObject slot3;
	public GameObject slot4;
	public GameObject slot5;
	public GameObject slot6;

	public AudioSource audio1;


	public void PlaySong(AudioClip s)
	{

	}

	public void RotateSongLeft()
	{
		if(songIndex < 1)
		{
			songIndex = songs.Count-1;

		}
		else
		{
			songIndex--;
		}

		slot3.GetComponent<Image>().sprite = songs[songIndex].icon;
	}
	public void RotateSongRight()
	{
		if (songIndex > songs.Count - 2) {
			songIndex = 0;
			
		} else {
			songIndex++;
		}
		
		slot3.GetComponent<Image> ().sprite = songs [songIndex].icon;
	}

	void Start () 
	{
		Sprite[] sprs = Resources.LoadAll<Sprite>("Carousel");
		foreach (Sprite spr in sprs) {
			Song s = new Song();
			s.icon = spr;
			songs.Add(s);
		}

		songIndex = 2;


	}
	

	void Update () 
	{

	
	}
}
