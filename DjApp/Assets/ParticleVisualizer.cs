using UnityEngine;
using System.Collections;

public class ParticleVisualizer : MonoBehaviour {
	ParticleSystem particles;
	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(particles.emissionRate>=1000)
			particles.emissionRate -= 1000;
	
	}
	public void VisualizeOnBeat()
	{
		particles.emissionRate += 1000;
	}
}
