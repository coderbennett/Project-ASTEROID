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
		if (isOver)
		{
			text.color = new Color(1f, 1f, 1f);
		} else
        {
			text.color = new Color(0.75f, 0.75f, 0.75f);
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(0) && isOver && gameObject.name == "startButton")
		{
			SceneManager.LoadScene("Space");
		}

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
