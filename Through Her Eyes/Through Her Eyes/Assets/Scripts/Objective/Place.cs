using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Place : Objective {
	
	public GameObject zone;
	public List<GameObject> items = new List<GameObject>();
	List<bool> itemStatus = new List<bool>();


	void Awake() {
		if (!zone.GetComponent<BoxCollider> ().isTrigger)
			Debug.Log ("Zone needs to be a trigger!");
		for (int i=0; i<items.Count; i++) {
			itemStatus.Add (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!active)
			return;
		
		bool done = true;
		for (int i=0; i<items.Count; i++) {
			if (zone.GetComponent<BoxCollider> ().bounds.Intersects (items [i].GetComponent<Collider>().bounds))
				itemStatus [i] = true;
			else
				done = false;
		}
		
		completed = done;
	}
	public override void SetActive(bool active){
		this.active = active;
	}
}
