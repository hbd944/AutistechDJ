using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchManager : MonoBehaviour
{
	public DJManager dj;
	public RectTransform frame;
	public int id;
	public AudioClip clip;




	void Start () 
	{
		frame = GetComponent<RectTransform> ();

	}


	public void Clicked()
	{
		dj.SongClicked(clip);
	}

	void Update () 
	{

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			int touchy = Input.GetTouch (0).position.x;
			if ( (frame.transform.position.y < 20 && touchy < 20) ) ||
					  (frame.transform.position.y > -80 && touchy > -80) ){

				if(touchDeltaPosition.x > 85)
				{
					touchDeltaPosition = new Vector3(85,touchDeltaPosition.y,touchDeltaPosition.z);
				}
				else
				if(touchDeltaPosition.x < -85)
				{
					touchDeltaPosition = new Vector3(-85,touchDeltaPosition.y,touchDeltaPosition.z);
				}
				
				//if(touchDeltaPosition.x < 0)
				//{
				//	dj.SendMessage("LeftSwipe",touchDeltaPosition.x);
				//}
				frame.Translate(new Vector3(touchDeltaPosition.x, 0, 0) );


				if ( (frame.localPosition.x > -200) && (frame.localPosition.x < 200))
				{
					frame.eulerAngles = new Vector3(0, frame.localPosition.x / 4, 0);
					
					//if(touchDeltaPosition != Vector3.zero)
					//GetComponent<RectTransform>().Translate(new Vector3(touchDeltaPosition.x, 0, 0) );
					
					//frame.localScale = new Vector3(1,1,1)*((1 + 200 - (Mathf.Abs (frame.localPosition.x)) )* .008f) ;
					//frame.localScale = new Vector3(1,1,1)*((1 + (200 - Mathf.Abs (frame.localPosition.x))/100)) ;
					
					
				}
				else
				{
					//float adj = (Mathf.Abs (frame.localPosition.x) - 200)/2.0f;
					//GetComponent<RectTransform>().Translate(new Vector3(touchDeltaPosition.x, 0, 0) );

				}

				if(frame.localPosition.x < -451)
				{

					//if(!dj.farRight)
					//{
					//	frame.localPosition = new Vector3(449,0,0);

					//}
					//else
					frame.localPosition = new Vector3(dj.farRight.localPosition.x+100,frame.localPosition.y,0);
					frame.eulerAngles = new Vector3(0, 50, 0);


					dj.farRight = frame;
					dj.MoveMeRight(id);
				}
				else
				if(frame.localPosition.x > 451)
				{

					//if(!dj.farRight)
					//{
					//	frame.localPosition = new Vector3(-449,0,0);
						
					//}
					//else
					frame.localPosition = new Vector3(dj.farLeft.localPosition.x-100,frame.localPosition.y,0);
					frame.eulerAngles = new Vector3(0, -50, 0);

					dj.farLeft = frame;
					dj.MoveMeLeft(id);
				}



				/*
				if(frame.localScale.magnitude < 1)
				{
					//frame.localScale = new Vector3(1,1,1);
				}

				if(frame.localScale.magnitude > 1.6f)
				{
					frame.localScale = new Vector3(1.6f,1.6f,1.6f);
					
				}
				*/

			}


			frame.localPosition = new Vector3(frame.localPosition.x,frame.localPosition.y,0);
		}
	}
}
