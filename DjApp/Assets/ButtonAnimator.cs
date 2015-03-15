using UnityEngine;
using System.Collections;

public class ButtonAnimator : MonoBehaviour 
{
	public float timer;
	public float maxTimer;
	public bool moving;
	public float rotateSpeed;
	public float translateSpeed;

	public bool movingOffscreen;
	public bool movingOnscreen;

	public float targetRotateY;
	public float targetTranslateX;

	public int state;

	RectTransform rT;

	public void MoveOneToTwo()
	{
		moving = true;
		timer = 0;
		maxTimer = 12.5f;
		rotateSpeed = 40.0f;
		translateSpeed = 360.0f;
		targetRotateY = 310;
		targetTranslateX = -155;

		state = 1;
	}


	public void MoveTwoToThree()
	{
		moving = true;
		timer = 0;
		maxTimer = 12.5f;
		rotateSpeed = 40.0f;
		translateSpeed = 210.0f;
		targetRotateY = 360;
		targetTranslateX = 0;

		state = 2;
	}

	public void MoveThreeToFour()
	{
		moving = true;
		timer = 0;
		maxTimer = 12.5f;
		rotateSpeed = 40.0f;
		translateSpeed = 185.0f;
		targetRotateY = 50;
		targetTranslateX = 155;

		state = 3;
	}

	public void MoveFourToFive()
	{
		moving = true;
		timer = 0;
		maxTimer = 12.5f;
		rotateSpeed = 40.0f;
		translateSpeed = 360.0f;
		targetRotateY = 80;
		targetTranslateX = 240;

		state = 4;
	}

	public void MoveFiveToSix()
	{
		moving = true;
		timer = 0;
		maxTimer = 12.5f;
		rotateSpeed = 40.0f;
		translateSpeed = 360.0f;
		targetRotateY = 90;
		targetTranslateX = -450;
		movingOffscreen = true;

		state = 5;
	}

	public void MoveSixToOne()
	{
		movingOffscreen = false;
		movingOnscreen = true;
		moving = true;
		timer = 0;
		maxTimer = 12.5f;
		rotateSpeed = 40.0f;
		translateSpeed = 360.0f;
		targetRotateY = 280;
		targetTranslateX = -240;

		state = 6;

	}

	void Start () 
	{
		rT = GetComponent<RectTransform>();
	}


	void SetRect()
	{
		switch(state)
		{
			case 1:
			rT.localPosition = new Vector3(-155,0,0);
			rT.eulerAngles = new Vector3(0,310,0);
			break;



			case 2:
			rT.localPosition = new Vector3(0,0,0);
			rT.eulerAngles = new Vector3(0,0,0);
			break;


			case 3:
			rT.localPosition = new Vector3(155,0,0);
			rT.eulerAngles = new Vector3(0,50,0);
			break;

			case 4:
			rT.localPosition = new Vector3(240,0,0);
			rT.eulerAngles = new Vector3(0,80,0);
			break;


			case 5:
			rT.localPosition = new Vector3(-416.4f,0,0);
			rT.eulerAngles = new Vector3(0,280,0);
			break;


			case 6:
			rT.localPosition = new Vector3(-240,0,0);
			rT.eulerAngles = new Vector3(0,-80,0);
			break;




		}

	}

	void Update () 
	{



		if(moving == true)
		{
			timer+=Time.deltaTime;

			if(rT.eulerAngles.y == 360 || rT.eulerAngles.y+rotateSpeed*Time.deltaTime > 355)
			{
				//rT.localRotation.eulerAngles 
				rT.eulerAngles = new Vector3(rT.localRotation.eulerAngles.x,targetRotateY,rT.localRotation.eulerAngles.z);
				rT.localPosition = new Vector3(targetTranslateX,rT.localPosition.y,rT.localPosition.z);
				moving = false;
				movingOffscreen = false;
				movingOnscreen = false;
				SetRect();
			}
			else
			{
				if(!movingOnscreen)
				rT.Rotate (new Vector3(0,rotateSpeed*Time.deltaTime,0));

				if(movingOffscreen)
				{
					//if(rT.eulerAngles.y < 90)
					rT.position = rT.position+Vector3.right;
					//else
					//rT.position = rT.position-Vector3.right;
				}
				if(movingOnscreen)
				{
					rT.Translate(new Vector3(5*Time.deltaTime,0,0));
				}
				else
					rT.Translate(new Vector3(translateSpeed*Time.deltaTime,0,0));
			}
			if(rT.eulerAngles.y > targetRotateY || rT.eulerAngles.y == 360 )
			{
				//rT.localRotation.eulerAngles 
				rT.eulerAngles = new Vector3(rT.localRotation.eulerAngles.x,targetRotateY,rT.localRotation.eulerAngles.z);
				rT.localPosition = new Vector3(targetTranslateX,rT.localPosition.y,rT.localPosition.z);
				moving = false;
				movingOffscreen = false;
				movingOnscreen = false;
				SetRect();
			}

			//if(rT.position.x > targetTranslateX)
		//	{
		//		rT.eulerAngles = new Vector3(rT.localRotation.eulerAngles.x,targetRotateY,rT.localRotation.eulerAngles.z);
		//		rT.position = new Vector3(targetTranslateX,rT.position.y,rT.position.z);
		//		moving = false;
		//	}

			if(timer >= maxTimer)
			{
				moving = false;
				movingOffscreen = false;
				movingOnscreen = false;
				SetRect();
			}
		}
	}
}
