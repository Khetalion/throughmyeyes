using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public GameObject PausePanel;
	public GameObject DebugPanel;
	public GameObject SpotPanel;
    public bool paused;
	// Use this for initialization
	void Start ()
    {
        paused = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(paused)
        {
            gamePaused(true);
        }
        else
        {
            gamePaused(false);
        }
        if(Input.GetButtonDown("Menu"))
        {
            pauseSwitch();
		}

		// Spot Handler
		int spot;
		//SpotPanel.transform.FindChild(

		// Debug Handler
		DebugPanel.SetActive (Input.GetButton("Debug"));
		DebugPanel.transform.FindChild ("Spot Intensity").GetComponent<Text> ().text = "Spot Intensity: " + 1;
	}

    // Pauses
    private void gamePaused(bool state)
    {
        if(state)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
        }
        PausePanel.SetActive(state);
    }

    public void pauseSwitch()
    {
        if(paused)
        {
            paused = false;
        }
        else
        {
            paused = true;
        }
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
