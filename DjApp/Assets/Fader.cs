using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour 
{
	public AudioClip clip1;
	public AudioClip clip2;

	public AudioSource source1;
	public AudioSource source2;

	public AudioSource fadeFrom;
	public AudioSource fadeTo;

	bool fading;

	public float fadeSpeed;

	void Start () 
	{
		
	}

	public void Test()
	{
		SwitchTracks(source1,source2);
	}

	void Update () 
	{
		if(fading)
		{
			fadeFrom.volume-=0.1f * Time.deltaTime *fadeSpeed;
			fadeTo.volume+=0.1f * Time.deltaTime *fadeSpeed;

			if(fadeFrom.volume < 0.5f && !fadeTo.isPlaying)
				fadeTo.Play();

			if(fadeFrom.volume < 0)
				fadeFrom.volume = 0;

			if(fadeTo.volume > 1.0f)
				fadeTo.volume = 1.0f;


			if(fadeTo.volume == 1.0f)
			{
				fadeFrom.volume = 0.0f;
				fadeFrom.Stop();
				fading = false;
			}
		}
	}

	public void SwitchTracks(AudioSource s1, AudioSource s2)
	{
		fadeFrom = s1;
		fadeTo = s2;
		s2.volume = 0.0f;

		fading = true;



	}
}
