using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {

	public Text text;
	private bool isOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if the mouse is over this button light it up
		if (isOver)
		{
			text.color = new Color(1f, 1f, 1f);
		//if the mouse is not over this button it will be grey
		} else
        {
			text.color = new Color(0.75f, 0.75f, 0.75f);
		}
	}

	private void FixedUpdate()
	{
		//if you left click the mouse over this game object and this game object's name is startButton, then start the game
		if (Input.GetMouseButtonDown(0) && isOver && gameObject.name == "startButton")
		{
			SceneManager.LoadScene("Space");
		}

		//if you left click the mouse over this game object and this game object's name is quitButton, then quit the game
		if (Input.GetMouseButtonDown(0) && isOver && gameObject.name == "quitButton")
		{
			Application.Quit();
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
