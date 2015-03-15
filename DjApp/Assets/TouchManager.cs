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
		Vector3 touchDeltaPosition = Vector3.zero;
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			//if(touchDeltaPosition.x < 0)
			//{
			//	dj.SendMessage("LeftSwipe",touchDeltaPosition.x);
			//}
			GetComponent<RectTransform>().Translate(new Vector3(touchDeltaPosition.x, 0, 0) );


			if ( (frame.localPosition.x > -200) && (frame.localPosition.x < 200))
			{
				frame.eulerAngles = new Vector3(0, frame.localPosition.x / 4, 0);
				
				if(touchDeltaPosition != Vector3.zero)
					GetComponent<RectTransform>().Translate(new Vector3(touchDeltaPosition.x, 0, 0) );
				
				//frame.localScale = new Vector3(1,1,1)*((1 + 200 - (Mathf.Abs (frame.localPosition.x)) )* .008f) ;
				//frame.localScale = new Vector3(1,1,1)*((1 + (200 - Mathf.Abs (frame.localPosition.x))/100)) ;
				
				
			}
			frame.localPosition = new Vector3(frame.localPosition.x,frame.localPosition.y,0);
			
			if(frame.localScale.magnitude < 1)
			{
				//frame.localScale = new Vector3(1,1,1);
			}
			else
				if(frame.localScale.magnitude > 1.6f)
			{
				//frame.localScale = new Vector3(1.6f,1.6f,1.6f);
				
			}
		}



	}
}
