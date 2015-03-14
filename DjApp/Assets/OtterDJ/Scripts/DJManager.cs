using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DJManager : MonoBehaviour 
{
	public List<AudioClip> songs = new List<AudioClip>();

	public AudioClip clip;

	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public AudioSource audio4;

	public void PlaySong()
	{

	}

	void Start () 
	{
		Debug.Log (clip.name);
	}
	

	void Update () 
	{
	
	}
}
