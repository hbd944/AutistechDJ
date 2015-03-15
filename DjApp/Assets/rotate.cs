using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		transform.RotateAround (transform.position, new Vector3 (0, 1, 1), 0.1f);
	}
}
