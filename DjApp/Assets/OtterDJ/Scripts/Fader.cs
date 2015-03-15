using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
	public AudioClip clip1;
	public AudioClip clip2;

	public AudioSource source1;
	public AudioSource source2;

	SyncAudio deck1;
	SyncAudio deck2;
	AudioProcessor processor;

	private AudioSource fadeFrom;
	private AudioSource fadeTo;

	private bool firstPlay = true;

	bool fading;

	bool state = false;

	public float fadeSpeed;

	public ParticleSystem pSystem;

	void Start()
	{
		SyncAudio[] temp = GetComponents<SyncAudio> ();
		deck1 = temp [0];
		deck2 = temp [1];
	}

	public void cueSong(AudioClip song)
	{
		if (!state) 
		{
			source2.clip = song;
		}
		else
		{
			source1.clip = song;
		}

		if (!firstPlay) {
			Test ();
		} else {
			firstPlay=false;
			source1.clip = song;
			source1.Play();
		}
	}

	public void Test()
	{
		if ((!source1.isPlaying)&&(!source2.isPlaying))
		{
			source1.Play();
		}
		else 
		{
			if (!state) {
				findFirstBeat (deck2);
				state = !state;
			} else {
				findFirstBeat (deck1);
				state = !state;
			}
		}
		
	}

	void Update () 
	{

		if (deck2.ready) 
		{
			deck2.ready=false;
			SwitchTracks(source1,source2);


		} 
		else if (deck1.ready) 
		{
			deck1.ready=false;
			SwitchTracks(source2,source1);

		}

		if(fading)
		{
			fadeFrom.volume-=0.1f * Time.deltaTime *fadeSpeed;

			if(fadeTo.isPlaying)
				fadeTo.volume+=0.1f * Time.deltaTime *fadeSpeed;

			if(fadeFrom.volume < 0.5f && !fadeTo.isPlaying)
				fadeTo.UnPause();

			if(fadeFrom.volume < 0)
			{
				fadeFrom.volume = 0;
			}

			if(fadeTo.volume > 1.0f)
				fadeTo.volume = 1.0f;


			if(fadeTo.volume == 1.0f)
			{
				fadeFrom.volume = 0.0f;
				//fadeFrom.Stop();
				fading = false;
				pSystem.gravityModifier = 0.0f;
			}
		}
	}

	public void SwitchTracks(AudioSource s1, AudioSource s2)
	{
		fadeFrom = s1;
		fadeTo = s2;
		s2.volume = 0.0f;


		fading = true;

		pSystem.gravityModifier = 1.0f;



	}

	public void findFirstBeat(SyncAudio source)
	{
		source.findBeat ();
	}
}
