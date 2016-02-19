using UnityEngine;
using System.Collections;

public class GrabAndDrop : MonoBehaviour {
	
	[Range(1,7)]
	public float range = 3.0f;
	GameObject grabbedObject;
	float grabbedObjectSize;

	GameObject GetMouseOverObject()
	{
		Vector3 position = gameObject.transform.position;
		RaycastHit rch;
		Vector3 target = position + Camera.main.transform.forward * range;

		if (Physics.Linecast (position, target, out rch)) 
		{
			return rch.collider.gameObject;
		}
		return null;
	}

	void TryGrabObject(GameObject obj)
	{
		if (obj == null || !CanGrab(obj)) 
		{
			return;
		}

		grabbedObject = obj;
		grabbedObjectSize = obj.GetComponent<Renderer>().bounds.size.magnitude;
	}

	bool CanGrab(GameObject obj)
	{
		return (obj.GetComponent<Rigidbody>() != null);
	}

	void DropObject()
	{
		if (grabbedObject == null) 
		{
			return;
		}

		if (grabbedObject.GetComponent<Rigidbody>() != null)
		{
			grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

		grabbedObject = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (grabbedObject == null) 
			{
				TryGrabObject (GetMouseOverObject ());
			} 
			else 
			{
				DropObject();
			}
		}

		if (grabbedObject != null)
		{
			Vector3 newPosition = gameObject.transform.position + 
				gameObject.transform.forward * grabbedObjectSize;
			grabbedObject.transform.position = newPosition;
		}
	}
}
