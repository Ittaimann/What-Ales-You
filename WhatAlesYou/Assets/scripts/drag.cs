using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DragingStatus
{
		idle,
		draging,
		returning
}
public class drag : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private Vector3 cursorPosition;
	private DragingStatus state;
	private bool originalGravity;

	public void Start()
	{
		state = DragingStatus.idle;
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		originalGravity = GetComponent<Rigidbody>().useGravity;
	}

	public void Update()
	{
		switch(state)
		{
			case DragingStatus.draging:
			{
				//if(transform.position != cursorPosition)
				//let the bottle to chase the cursor
				//{
				Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
				cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
				transform.position += (cursorPosition - transform.position)/20;
				//}
				break;
				
			}

			case DragingStatus.returning:
			{
				transform.position = Vector3.MoveTowards(transform.position, originalPosition, 0.5f);
				//set the Potion back when it's closer enough to original position
				if(Vector3.Distance(transform.position,originalPosition) <= 1f)
				{
					transform.position = originalPosition;
					transform.rotation = originalRotation;
					GetComponent<Rigidbody>().useGravity = originalGravity;
					GetComponent<Rigidbody>().velocity = Vector3.zero;
					GetComponent<Rigidbody>().freezeRotation = true; //Stop!
					state = DragingStatus.idle;
				}
				break;
			}

		}

		

	}

	void OnMouseDown(){
		//begin to drad, remove gravity
		if(state == DragingStatus.idle)
		{
			state = DragingStatus.draging;
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().freezeRotation = false;
			//calculate the offset
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			//set initial position of cursor
			Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		}
		
	}

	public void OnMouseUp()
	{
		if(state == DragingStatus.draging)
		{
			ReturnBack();
		}
	}

	public void ReturnBack()
	{
		state = DragingStatus.returning;
	}

	public DragingStatus GetStatus()
	{
		return state;
	}

}