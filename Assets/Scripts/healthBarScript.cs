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

	public static bool paused = false;
	public static bool gameover = false;

	// Use this for initialization
	void Start () {
		//find the earth game object within the scene
		earth = GameObject.Find("Earth");
		//find the scoreboard within the scene
		scoreBoard = GameObject.FindWithTag("Score Board");
		//set the audio source as the one connected to this object
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//constantly update the animation for the health with the health integer variable
		animator.SetInteger("health", health);
		//if it is time to add score, the game is not paused, and the object "Health" is using this script (specify health so this doesnt occur twice)
		if (scoreNow && gameObject.name == "Health" && !paused)
		{
			//set the scoreNow variable false for now
			scoreNow = false;
			//invoke the healthScore method in 10 seconds
			Invoke("healthScore", 10f);
		}

		//if the health of the earth is within one of these ranges, change the color of the floating text score
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

		if (health == 0)
        {
			gameover = true;
        }
	}

	private void FixedUpdate()
	{
		//if you press the escape key, the game is paused and the object with this script is named health, pause the game
		if (Input.GetKey(KeyCode.Escape) && !paused && gameObject.name == "Health")
		{
			paused = true;
		}
	}

	//this method inflicts damage to the earth
		public void healthDamaged()
    {
		health--;
		//make sure to have only one game object play this sound
		if (gameObject.name == "Health")
		{
			audio.Play();
		}
	}

	void healthScore()
	{
		if (!paused)
		{
			//create a floating text object with the amount of health x3
			scoreScript scoreboard = (scoreScript)scoreBoard.GetComponent(typeof(scoreScript));
			floatingTextController.CreateFloatingText("+" + (health * 3).ToString(), earth.transform, false, healthColor);
			scoreboard.increaseScore((health * 3));
		}
		//reset the boolean to true, allowing the scoring continue
		scoreNow = true;
	}
}
