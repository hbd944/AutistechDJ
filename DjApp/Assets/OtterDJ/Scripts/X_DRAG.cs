using UnityEngine;
using System.Collections;

public class X_DRAG : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;
	public bool dragging;

	void OnPointerDown()
	{
			DoAaThing ();
	}

	void DoAaThing() {
		Debug.Log ("something");
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, 0, 0);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;
	}

}