using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DJManager : MonoBehaviour 
{
	public List<Song> songs = new List<Song>();

	public int songIndex;

	public GameObject[] buttons;

	public RectTransform farRight;
	public RectTransform farLeft;

	public void orderRender(){
		GameObject center = buttons [0];

		foreach(GameObject thisButton in buttons){
			if (Mathf.Abs (thisButton.GetComponent<RectTransform>().localPosition.x) < Mathf.Abs (center.GetComponent<RectTransform>().localPosition.x))
			{
				center = thisButton;
			}
		}
		int myIndex = center.GetComponent<TouchManager>().id;

	}

	public GameObject getLeftChild(GameObject me){
		///!!!!
	}



	public void MoveMeLeft(int id)
	{
		if(id == 0)
		{
			farRight = buttons[6].GetComponent<RectTransform>();
		}
		else
		{
			farRight = buttons[id-1].GetComponent<RectTransform>();
		}
	}
	public void MoveMeRight(int id)
	{
		if(id == 6)
		{
			farLeft = buttons[0].GetComponent<RectTransform>();
		}
		else
		{
			farLeft = buttons[id+1].GetComponent<RectTransform>();
		}
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

		for(int i = 0; i < buttons.Length; i++)
		{
			buttons[i].GetComponent<TouchManager>().id = i;
		}
	}
	

	void Update () 
	{

	}
}
