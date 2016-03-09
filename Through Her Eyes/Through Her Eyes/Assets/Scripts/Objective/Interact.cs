using UnityEngine;
using System.Collections;

public class Interact : Objective {

	public GameObject item;

	void Awake() {
		if (item == null){
			Debug.Log ("Interactable object can't be null!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!active)
			return;
		if (item.GetComponent<Interactable> ().interacted)
			completed = true;
	}
	public override void SetActive(bool active){
		this.active = active;
		item.GetComponent<Interactable> ().interacted = false;
	}
}
