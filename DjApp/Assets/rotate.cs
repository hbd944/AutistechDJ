using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	bool osc = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		transform.RotateAround (transform.position, new Vector3 (0, 1, 1), 0.1f);
		if (osc)
			transform.position = (new Vector3 (transform.position.x,
			                                 transform.position.y,
			                                   transform.position.z+0.1f));
		else
			transform.position = (new Vector3 (transform.position.x,
			                                   transform.position.y,
			                                   transform.position.z-0.1f));
		if ((transform.position.z >= 150)||transform.position.z <= 30) 
			osc=!osc;
	}
}
