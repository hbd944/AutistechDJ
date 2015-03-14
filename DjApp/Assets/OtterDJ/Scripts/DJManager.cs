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
	public Button b3; //Middle Song which is the 'main playing'
	public Button b4;
	public Button b5;

	public Image image;

	public AudioClip clip;
	public Sprite icon;

	public AudioClip clip2;
	public Sprite icon2;

	public AudioClip clip3;
	public Sprite icon3;

	public AudioClip clip4;
	public Sprite icon4;

	public AudioClip clip5;
	public Sprite icon5;

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public AudioSource audio4;

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

		//b3.gameObject.GetComponent<Image>().sprite = songs[songIndex].icon;
		image.overrideSprite = songs[songIndex].icon;
	}
	public void RotateSongRight()
	{
		if(songIndex > songs.Count-1)
		{
			songIndex = 0;
			
		}
		else
		{
			songIndex++;
		}
		
		//b3.gameObject.GetComponent<Image>().sprite = songs[songIndex].icon;
		image.overrideSprite = songs[songIndex].icon;
	}

	void Start () 
	{

		songIndex = 2;

	
	
	

		//b3.GetComponent<Button>().

		Song s1 = new Song();

		//s1.song = clip;
		s1.icon = icon;
		songs.Add(s1);

		Song s2 = new Song();
		//s1.song = clip2;
		s2.icon = icon2;
		songs.Add(s2);

		Song s3 = new Song();
		//s1.song = clip3;
		s3.icon = icon3;
		songs.Add(s3);

		Song s4 = new Song();
		//s1.song = clip4;
		s4.icon = icon4;
		songs.Add(s4);

		Song s5 = new Song();
		//s1.song = clip5;
		s5.icon = icon5;
		songs.Add(s5);

		image.overrideSprite = songs[songIndex].icon;

	}
	

	void Update () 
	{
	
	}
}
