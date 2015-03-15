using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class songList : MonoBehaviour {

	public Fader fader;

	public List<AudioClip> songs;

	public void playRandomSong()
	{
		fader.cueSong(songs[Random.Range(0,songs.Count-1)]);
	}
}
