using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour {

	public Animator animator;
	public AudioSource audio;

	public int health = 9;

	private GameObject earth;

	private bool scoreNow = true;
	private GameObject scoreBoard;
	private string healthColor;

	private Vector3 location;

	// Use this for initialization
	void Start () {
		earth = GameObject.Find("Earth");
		scoreBoard = GameObject.FindWithTag("Score Board");
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("health", health);
		if (scoreNow && gameObject.name == "Health")
		{
			scoreNow = false;
			Invoke("healthScore", 10f);
		}

		if (health > 7)
        {
			//light green color
			healthColor = "green";
        } else if (health < 8 && health > 5)
        {
			//gold yellow
			healthColor = "yellow";
		} else if (health < 6 && health > 1)
        {
			//orange
			healthColor = "orange";
        } else if (health == 1)
        {
			//tomato red
			healthColor = "red";
		}
	}

	public void healthDamaged()
    {
		health--;
		if (gameObject.name == "Health")
		{
			audio.Play();
		}
	}

	void healthScore()
	{
		scoreScript scoreboard = (scoreScript)scoreBoard.GetComponent(typeof(scoreScript));
		floatingTextController.CreateFloatingText("+" + (health*3).ToString(), earth.transform, false, healthColor);
		scoreboard.increaseScore((health*3));
		scoreNow = true;
	}
}
