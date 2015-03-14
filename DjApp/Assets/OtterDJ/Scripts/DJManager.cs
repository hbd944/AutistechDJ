using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DJManager : MonoBehaviour 
{
	public List<Song> songs = new List<Song>();

	public int songIndex;

	public Button b1;
	public Button b2;
	public Button b3;
	public Button b4;
	public Button b5;

	public AudioClip clip;
	public Texture2D icon;

	public AudioClip clip2;
	public Texture2D icon2;

	public AudioClip clip3;
	public Texture2D icon3;

	public AudioClip clip4;
	public Texture2D icon4;

	public AudioClip clip5;
	public Texture2D icon5;

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public AudioSource audio4;

	public void PlaySong()
	{

	}

	void Start () 
	{
		Song s1 = new Song();

		//s1.song = clip;
		s1.icon = icon;
		songs.Add(s1);

		//s1.song = clip2;
		s1.icon = icon2;
		songs.Add(s1);

		//s1.song = clip3;
		s1.icon = icon3;
		songs.Add(s1);

		//s1.song = clip4;
		s1.icon = icon4;
		songs.Add(s1);

		//s1.song = clip5;
		s1.icon = icon5;
		songs.Add(s1);

	}
	

	void Update () 
	{
	
	}
}
