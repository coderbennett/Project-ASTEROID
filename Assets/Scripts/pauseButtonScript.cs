using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseButtonScript : MonoBehaviour {

	public Text text;
	private bool isOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if the mouse is over this button and the game is paused, light it up
		if (isOver && healthBarScript.paused)
		{
			text.color = new Color(1f, 1f, 1f, 1f);
		//if the mouse is not over the button but the game is paused, make the text gray
		} else if (!isOver && healthBarScript.paused)
		{
			text.color = new Color(0.75f, 0.75f, 0.75f, 1f);
		//if the game is not paused make this button invisible
		} else if (!healthBarScript.paused)
        {
			text.color = new Color(0.75f, 0.75f, 0.75f, 0f);
		}
	}

	private void FixedUpdate()
	{
		//if you click this button while the game is paused and if this button is the resume button, unpause the game
		if (Input.GetMouseButtonDown(0) && isOver && healthBarScript.paused && text.name == "resume")
		{
			healthBarScript.paused = false;
		}
		//if you click this button while the game is paused and if this button is the quit button, go to the main menu
		if (Input.GetMouseButtonDown(0) && isOver && healthBarScript.paused && text.name == "quit")
		{
			healthBarScript.paused = false;
			SceneManager.LoadScene("Menu");
		}
	}

	public void OnMouseEnter()
	{
		isOver = true;
	}

	public void OnMouseExit()
	{
		isOver = false;
	}
}
