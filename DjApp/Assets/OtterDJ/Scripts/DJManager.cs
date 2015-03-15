using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DJManager : MonoBehaviour 
{
	public List<Song> songs = new List<Song>();

	public int songIndex;

	public GameObject slot0;
	public GameObject slot1;
	public GameObject slot2;
	public GameObject slot3;
	public GameObject slot4;
	public GameObject slot5;
	public GameObject slot6;

	public AudioSource audio1;

	public bool triggered;

	public float cooldown;

	public GameObject[] buttons;


	public void PlaySong(AudioClip s)
	{

	}



	public void LeftSwipe(float sw)
	{
		float farRight = 485;
		foreach(GameObject go in buttons)
		{
			go.GetComponent<RectTransform>().Translate (new Vector3(sw*3,0,0));

			if(go.GetComponent<RectTransform>().localPosition.x+150 > 485)
			{
				if(go.GetComponent<RectTransform>().localPosition.x > farRight)
				{
					farRight = go.GetComponent<RectTransform>().localPosition.x+150;
				}

			}
			if(go.GetComponent<RectTransform>().localPosition.x+150 < -480)
			{
				if(farRight > 485)
				{
					go.GetComponent<RectTransform>().localPosition = new Vector3(farRight,go.GetComponent<RectTransform>().localPosition.y,go.GetComponent<RectTransform>().localPosition.z);
			
				
				}
				else
				{
					go.GetComponent<RectTransform>().localPosition = new Vector3(485,go.GetComponent<RectTransform>().localPosition.y,go.GetComponent<RectTransform>().localPosition.z);

				}
			}
		}
		//if(cooldown <= 0)
		//{
			//RotateLeft();

		///	//cooldown = 2.0f;
		//}
	}

	public void RightSwipe(float sw)
	{
		float farRight = 485;
		foreach(GameObject go in buttons)
		{
			go.GetComponent<RectTransform>().Translate (new Vector3(sw,0,0));
			
			if(go.GetComponent<RectTransform>().localPosition.x > 485)
			{
				if(go.GetComponent<RectTransform>().localPosition.x > farRight)
				{
					farRight = go.GetComponent<RectTransform>().localPosition.x;
				}
				
			}
			if(go.GetComponent<RectTransform>().localPosition.x < -480)
			{
				if(farRight > 485)
				{
					go.GetComponent<RectTransform>().localPosition = new Vector3(farRight+150,go.GetComponent<RectTransform>().localPosition.y,go.GetComponent<RectTransform>().localPosition.z);
					
					
				}
				else
				{
					go.GetComponent<RectTransform>().localPosition = new Vector3(485,go.GetComponent<RectTransform>().localPosition.y,go.GetComponent<RectTransform>().localPosition.z);
					
				}
			}
		}
		//if(cooldown <= 0)
		//{
		//RotateLeft();
		
		///	//cooldown = 2.0f;
		//}
	}

	public void RotateLeft()		
	{
	//	slot0.GetComponent<ButtonAnimator>().MoveSixToOne ();
	//	slot1.GetComponent<ButtonAnimator>().MoveTwoToThree ();
	//	slot2.GetComponent<ButtonAnimator>().MoveTwoToThree();
	//	slot3.GetComponent<ButtonAnimator>().MoveTwoToThree();
	//	slot1.GetComponent<RectTransform>().position = Vector3.zero;

		slot0.SendMessage ("MoveOneToTwo");
		slot1.SendMessage ("MoveTwoToThree");
		slot2.SendMessage ("MoveThreeToFour");
		slot3.SendMessage ("MoveFourToFive");
		slot4.SendMessage ("MoveFiveToSix");
		slot5.SendMessage ("MoveSixToOne");

		GameObject tmp;

		tmp = slot0;

		slot0 = slot1;
		slot1 = slot2;
		slot2 = slot3;
		slot4 = slot5;
		slot5 = slot6;
		slot6 = tmp;
	}

	public void RotateSongLeft()
	{
		if(songIndex < 1)
		{
			songIndex = songs.Count-1;

		}
		else
		{
			songIndex--;
		}

		slot3.GetComponent<Image>().sprite = songs[songIndex].icon;
	}
	public void RotateSongRight()
	{
		if (songIndex > songs.Count - 2) {
			songIndex = 0;
			
		} else {
			songIndex++;
		}
		
		slot3.GetComponent<Image> ().sprite = songs [songIndex].icon;
	}

	void Start () 
	{
		Sprite[] sprs = Resources.LoadAll<Sprite>("Carousel");
		foreach (Sprite spr in sprs) {
			Song s = new Song();
			s.icon = spr;
			songs.Add(s);
		}

		songIndex = 2;


	}
	

	void Update () 
	{
		if(cooldown > 0)
			cooldown-=Time.deltaTime;

		if(Input.GetMouseButton (0))
		{
			//LeftSwipe();
		}
	}
}
