using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseButtonScript : MonoBehaviour {

	public Text text;
	public Text text2;
	public string color;
	private bool isOver = false;
	private Collider2D boxCollider;
	private bool isActivated = true;

	// Use this for initialization
	void Start ()
	{
		boxCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!healthBarScript.paused && !healthBarScript.gameover && isActivated)
        {
			DeactivateCollider();
		}

		if ((healthBarScript.paused || healthBarScript.gameover) && !isActivated)
        {
			ActivateCollider();
        }

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

		//if the mouse is over this button and the game is paused, light it up
		if (isOver && healthBarScript.gameover)
		{
			if (color == "red")
            {
				text2.color = new Color(1f, 0f, 0f, 1f);
			}

			if (color == "green")
            {
				text2.color = new Color(0f, 1f, 0f, 1f);
			}

		    if (color == "white")
            {
				text.color = new Color(1f, 1f, 1f, 1f);
			}
			//if the mouse is not over the button but the game is paused, make the text gray
		}
		else if (!isOver && healthBarScript.gameover)
		{
			if (color == "red")
			{
				text2.color = new Color(0.69f, 0f, 0f, 1f);
			}

			if (color == "green")
			{
				text2.color = new Color(0f, 0.69f, 0f, 1f);
			}

			if (color == "white")
			{
				text.color = new Color(0.75f, 0.75f, 0.75f, 1f);
			}
			//if the game is not paused make this button invisible
		}
		else if (!healthBarScript.gameover)
		{
			text2.color = new Color(0.75f, 0.75f, 0.75f, 0f);
		}
	}

	private void FixedUpdate()
	{
		//if you click this button while the game is paused and if this button is the resume button, unpause the game
		if (Input.GetMouseButtonDown(0) && isOver && healthBarScript.paused && text.name == "resume")
		{
			healthBarScript.paused = false;
		}

		//if you click this button while the game is paused (or gameover) and if this button is the quit button, go to the main menu
		if (Input.GetMouseButtonDown(0) && isOver && (healthBarScript.paused || healthBarScript.gameover) && text.name == "quit")
		{
			healthBarScript.paused = false;
			healthBarScript.gameover = false;
			scoreScript.score = 0;
			SceneManager.LoadScene("Menu");
		}

		if (Input.GetMouseButtonDown(0) && isOver && healthBarScript.gameover && text2.name == "retry")
		{
			healthBarScript.gameover = false;
			scoreScript.score = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (Input.GetMouseButtonDown(0) && isOver && healthBarScript.gameover && text2.name == "highscores")
		{
			healthBarScript.gameover = false;
			scoreScript.score = 0;
			SceneManager.LoadScene("Highscores");
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

	public void ActivateCollider()
	{
		boxCollider.enabled = true;
		isActivated = true;
	}

	public void DeactivateCollider()
	{
		boxCollider.enabled = false;
		isActivated = false;
	}
}
