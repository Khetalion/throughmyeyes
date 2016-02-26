using UnityEngine;
using System.Collections;

public class Grabable : MonoBehaviour {

    private Color startColor;
    //Shader startShader;
	Renderer rend;

	// Use this for initialization
	void Start () 
    {
		rend = GetComponent<Renderer> ();
		//startShader = rend.material.shader;
		startColor = rend.material.color;
	}

	void Update(){
		rend.material.color = startColor;
	}
	
	// Update is called once per frame
	public void Hover () 
    {
		rend.material.color = Color.green;
	}
}
