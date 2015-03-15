using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchManager : MonoBehaviour
{
	public DJManager dj;
	public RectTransform frame;


	void Start () 
	{
		frame = GetComponent<RectTransform> ();
	}
	

	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			if(touchDeltaPosition.x < 0)
			{
				dj.SendMessage("LeftSwipe",touchDeltaPosition.x);
			}
			GetComponent<RectTransform>().Translate(new Vector3(touchDeltaPosition.x * 5, 0, 0) );
		}

		if ( (frame.localPosition.x > -200) && (frame.localPosition.x < 200)){
			frame.eulerAngles = new Vector3(0, frame.localPosition.x / 4, 0);
		}
	}
}
