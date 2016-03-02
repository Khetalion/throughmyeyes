using UnityEngine;
using System.Collections;

public class Grabable : MonoBehaviour {

    private Color startColor;
	bool skip = false;
    //Shader startShader;
	Renderer rend;

	// Use this for initialization
	void Start () 
    {
		rend = GetComponent<MeshRenderer> ();
		//startShader = rend.material.shader;
		startColor = rend.material.color;
	}

	void Update(){

		if (!skip)
			rend.material.color = startColor;
		else
			skip = !skip;
	}


	public void Hover () {
		rend.material.color = Color.green;
		skip = true;
	}
}
