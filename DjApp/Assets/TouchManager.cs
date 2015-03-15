using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
	public DJManager dj;


	void Start () 
	{
	
	}
	

	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			if(touchDeltaPosition.x < 0)
			{
				dj.SendMessage("LeftSwipe",touchDeltaPosition.x);
			}
		}

	}
}
