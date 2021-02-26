using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour {

	public Animator animator;

	public int health = 9;

	private GameObject earth;

	private bool scoreNow = true;
	private GameObject scoreBoard;
	private Color healthColor;

	private Vector3 location;

	// Use this for initialization
	void Start () {
		earth = GameObject.Find("Earth");
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("health", health);
		if (scoreNow)
		{
			scoreNow = false;
			Invoke("healthScore", 10f);
		}

		if (health > 7)
        {
			//light green color
			healthColor = new Color(0.49f, 0.99f, 0f);
        } else if (health < 8 && health > 5)
        {
			//gold yellow
			healthColor = new Color(1.0f, 0.84f, 0f);
		} else if (health < 6 && health > 1)
        {
			//orange
			healthColor = new Color(1.0f, 0.55f, 0f);
        } else if (health == 1)
        {
			//tomato red
			healthColor = new Color(1.0f, 0.27f, 0f);
		}
	}

	public void healthDamaged()
    {
		health--;
	}

	void healthScore()
	{
		scoreBoard = GameObject.FindWithTag("Score Board");
		scoreScript scoreboard = (scoreScript)scoreBoard.GetComponent(typeof(scoreScript));
		floatingTextController.CreateFloatingText((health*2).ToString(), earth.transform, healthColor);
		scoreboard.increaseScore(health);
		scoreNow = true;
	}
}
