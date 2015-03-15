using UnityEngine;
using System.Collections;

public class SyncAudio : MonoBehaviour , AudioProcessor.AudioCallbacks
{
	public GameObject deck;
	AudioProcessor processor;
	public ParticleVisualizer visualizer;
	float prevTime;
	void Start()
	{
		//Select the instance of AudioProcessor and pass a reference
		//to this object
		processor = deck.GetComponent<AudioProcessor>();
		prevTime = Time.time;
		processor.addAudioCallback(this);
	}

	public void onOnbeatDetected()
	{
		Debug.Log("Beat!!!");
		Debug.Log(Time.time - prevTime);
		prevTime = Time.time;
		visualizer.VisualizeOnBeat ();
	}

	public void onSpectrum(float[] spectrum)
	{
		//The spectrum is logarithmically averaged
		//to 12 bands
		
		for (int i = 0; i < spectrum.Length; ++i)
		{
			Vector3 start = new Vector3(i-5, 0, 0);
			Vector3 end = new Vector3(i-5, spectrum[i]*4, 0);
			Debug.DrawLine(start, end);
		}
	}
	
	public void findBeat()
	{
		
	}
	
}
