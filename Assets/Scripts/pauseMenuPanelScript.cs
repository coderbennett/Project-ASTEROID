using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenuPanelScript : MonoBehaviour {

	public Image panel;
	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if the game is not paused, make these objects invisible
		if (!healthBarScript.paused)
		{
			panel.color = new Color(0.75f, 0.75f, 0.75f, 0f);
			text.color = new Color(0.75f, 0.75f, 0.75f, 0f);
		}
		//if the game is paused, make these objects visible
		if (healthBarScript.paused)
		{
			panel.color = new Color(0.75f, 0.75f, 0.75f, 1f);
			text.color = new Color(0.75f, 0.75f, 0.75f, 1f);
		}
	}
}
