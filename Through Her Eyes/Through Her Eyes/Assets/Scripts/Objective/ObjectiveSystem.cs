using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjectiveSystem : MonoBehaviour{

	public GameObject UIObjectPrefab;
	public GameObject ObjectivePanel;
	public List<Objective> currentObjectives = new List<Objective>();
	Queue<Objective> remove = new Queue<Objective>();
	int counter;

	// Use this for initialization
	void Awake () {
		counter = 0;
		for (int i=0; i<currentObjectives.Count; i++) {
			AddToUI (currentObjectives [i]);
			currentObjectives[i].SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<currentObjectives.Count; i++) {
			if(currentObjectives[i].completed){
				Objective next = currentObjectives[i].next;

				currentObjectives[i].SetActive(false);
				ObjectivePanel.transform.FindChild(currentObjectives[i].name).FindChild("Check").gameObject.SetActive(true);
				remove.Enqueue(currentObjectives[i]);
				if(next == null){
					Debug.Log ("End of objective chain");
					continue;
				}
				next.prereqs.Remove (currentObjectives[i]);
				if(next.prereqs.Count == 0){
					Debug.Log ("Added another objective");
					next.SetActive(true);
					currentObjectives.Add (next);
					AddToUI(next);
				}
			}
		}
		for (int i=0; i<remove.Count; i++)
			currentObjectives.Remove (remove.Dequeue ());
	}

	void AddToUI(Objective o)
	{
		GameObject go = Instantiate(UIObjectPrefab);
		Vector3 mod = new Vector3 (0, -counter * 40, 0);
		go.name = o.gameObject.name;
		go.transform.FindChild("Text").GetComponent<Text>().text = o.description;
		go.transform.SetParent(ObjectivePanel.transform, false);
		go.transform.localPosition = go.transform.localPosition + mod;
		counter++;
	}
}
