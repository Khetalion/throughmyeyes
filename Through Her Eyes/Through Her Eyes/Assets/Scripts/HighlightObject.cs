using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour {

    private Color startColor;
    public Shader startShader;
    public Renderer rend;

	// Use this for initialization
	void Start () 
    {
        rend = GetComponent<Renderer>();
        startShader = rend.material.shader;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    void OnTriggerStay()
    {
        //rend.material.shader = Shader.Find("Outlined_Diffuse");
    }

    void OnTriggerExit()
    {
        //rend.material.shader = startShader;
    }

    void OnMouseEnter()
    {
        startColor = rend.material.color;
        rend.material.color = Color.green;
    }

    void OnMouseOver()
    {
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
