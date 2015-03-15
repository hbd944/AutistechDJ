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
			Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			//if(touchDeltaPosition.x < 0)
			//{
			//	dj.SendMessage("LeftSwipe",touchDeltaPosition.x);
			//}
			GetComponent<RectTransform>().Translate(new Vector3(touchDeltaPosition.x * 2, 0, 0) );
		}

	}
}
