using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	public GameObject asteroid;
	public GameObject destroyAnimation;
	public GameObject markAnimation;
	private bool isOver = false;
	public Animator animator;
	public Rigidbody2D rb;
	private Vector3 mousePosition;
	public float moveSpeed = 20f;
	public bool orbitting = false;

	private Transform parent;
	private float distancefromParent;
	private float gDistance = 330;
	private GameObject spawnHub;
	private spawnerScript spawnHubScript;

	private int asteroidScore;
	private int asteroidMiningRate = 4;
	private int asteroidScoreMax = 400;
	private int asteroidLevel = 0;
	private bool scoreNow = true;
	private GameObject scoreBoard;

	public float homingSpeed = 0.5f;
	private float currentSpeed;
	private bool isPaused = false;

	private GameObject earth;
	private GameObject healthbar;
	private GameObject healthsymbol;

	public SpriteRenderer sprite;
	private string color = "gray";
	private int luck;

	public AudioSource audio;
	private bool audioOn = false;

	private bool isMarked = false;

		private void OnTriggerEnter2D(Collider2D collision)
	{
		//if the asteroid collides with Earth
		if (collision.tag == "Earth")
		{
			//find the earth health related game objects
			healthbar = GameObject.FindWithTag("Health Bar");
			healthsymbol = GameObject.FindWithTag("Health Symbol");
			//spawn in the destroyed animation for the asteroid
			SpawnDestroyAnimation(transform.position);
			//find the script for the health bar and health symbol and inflict the damage
			healthBarScript healthBar = (healthBarScript)healthbar.GetComponent(typeof(healthBarScript));
			healthBar.healthDamaged();
			healthBarScript healthSymbol = (healthBarScript)healthsymbol.GetComponent(typeof(healthBarScript));
			healthSymbol.healthDamaged();
			//reduce the total number of total asteroid counter
			spawnerScript.totalAsteroids--;
			//destroy this asteroid
			Destroy(gameObject);
		}

		//if the asteroid collides with the camera's boundary
		if (collision.tag == "MainCamera")
		{
			//reduce the total & destroy this asteroid
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		//if the asteroid collides with another asteroid destroy itself
		if (collision.tag == "Asteroid")
		{
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		//if the asteroid collides with the moon destroy the asteroid
		if (collision.tag == "Moon")
		{
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		//if the asteroid collides with a gravitational force
		if (collision.tag == "Gravity")
		{
			//identify which object's gravitational pull we collided with and set it to the parent variable
			parent = collision.transform;

			//if we collided with earth's gravitational pull while at a slow speed
			if (parent.name == "Earth Gravitational Pull" && homingSpeed < 1f)
			{
				//set the orbitting variable to true
				orbitting = true;
				//set the distance of the gravitational pull
				gDistance = 1000;
			}

			//same if statement as above just different standards for the moon than they were for the earth
			else if (parent.name == "Moon Gravitational Pull")
			{
				orbitting = true;
				gDistance = 500;
				if (homingSpeed > 1f)
                {
					homingSpeed = 0.5f;
                }
			}
		} 
	}

	//this method instantiates the destroy animation at the asteroid's location
	public void SpawnDestroyAnimation(Vector3 position)
	{
		Instantiate(destroyAnimation, position, Quaternion.identity);
	}

	//this method spawns a mark at the asteroid's location, and makes it a child to the asteroid
	public void SpawnMarkedAnimation(Vector3 position)
	{
		GameObject mark = Instantiate(markAnimation, position, Quaternion.identity);
		mark.transform.SetParent(transform);
	}

	void Update()
	{
		//if the game is not paused but this object is paused, unpause it
		if (!healthBarScript.paused && isPaused)
        {
			homingSpeed = currentSpeed;
			isPaused = false;
        }

		//while the game is not paused & the local isPaused variable is false, constantly store the current speed of the asteroid
		if (!healthBarScript.paused && !isPaused)
        {
			currentSpeed = homingSpeed;
        }

		//if the game is paused, set the homing speed to zero
		if (healthBarScript.paused)
        {
			homingSpeed = 0f;
			isPaused = true;
        }

		//if it is time to add score points, the asteroid is orbitting, and it is not paused, then...
		if (scoreNow && orbitting && !healthBarScript.paused)
		{
			//create a floating text with the color of the asteroid type, at the asteroid's location and with the amount of score
			floatingTextController.CreateFloatingText("+" + asteroidMiningRate.ToString(), transform, false, color);
			//grab the scoreboard script component so we can use the increaseScore method and increase the score
			scoreScript scoreboard = (scoreScript)scoreBoard.GetComponent(typeof(scoreScript));
			scoreboard.increaseScore(asteroidMiningRate);
			asteroidScore += asteroidMiningRate;
			//set score now to false
			scoreNow = false;
			//invoke this function in 6 seconds, it will reset scoreNow to true, allowing the score to be updated again
			Invoke("WaitTime", 6f);
		}

		//if the asteroid is orbitting something
		if (orbitting)
		{
			//set the parent of the asteroid to the current object maintaining gravitational pull
			GravitationalPull(parent);
			//check the distance from the parent object
			distancefromParent = Vector3.Distance(parent.position, transform.position);
			//if the asteroid has gotten too far from the object then sever the gravitational connection
			//this is formatted in such a way that if the numbers become negative/positive, the distance is calculated the same
			if (distancefromParent < 0 && distancefromParent < (gDistance * -1))
			{
				asteroid.transform.SetParent(null);
			}
			if (distancefromParent > 0 && distancefromParent > gDistance)
			{
				asteroid.transform.SetParent(null);
			}
		}
		//this is going to constantly update the animation parameter to let us know if the mouse is on top of the asteroid or not
		animator.SetBool("isOver", isOver);

		//these if statements measure the asteroid's farming progress
		//if the asteroid has been mined for at least 51 score points and it is at level 0
		if (asteroidScore > 50 && asteroidLevel == 0)
        {
			//increase the rate of which you gain score points from this asteroid
			asteroidMiningRate += 2;
			//increase the asteroid level
			asteroidLevel = 1;
			//spawn floating text to let the player know that the mining rate has been increased
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 100 && asteroidLevel == 1)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 2;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 150 && asteroidLevel == 2)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 3;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 200 && asteroidLevel == 3)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 4;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 250 && asteroidLevel == 4)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 5;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 300 && asteroidLevel == 5)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 6;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 350 && asteroidLevel == 6)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 7;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		if (asteroidScore > 375 && asteroidLevel == 7)
		{
			asteroidMiningRate += 2;
			asteroidLevel = 8;
			floatingTextController.CreateFloatingText("mining rate increased", transform, true, color);
		}

		//if the asteroid has reached the maximum amount of score it can give, destroy it
		if (asteroidScore == asteroidScoreMax)
        {
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}
	}

	//this will track the mouse movement (if it is over the asteroid)
	public void OnMouseEnter()
	{
		isOver = true;
	}

	//this will let us know if the mouse has gone away from the asteroid
	public void OnMouseExit()
	{
		isOver = false;
	}

	private void FixedUpdate()
	{
		//move the asteroid towards earth at the specified speed
		transform.position = Vector3.MoveTowards(transform.position, earth.transform.position, homingSpeed);
		//if you left click on the asteroid with your mouse while it is not already marked for death and the game is not paused, initiate it's destruction
		if (Input.GetMouseButtonDown(0) && isOver && !isMarked && !healthBarScript.paused)
		{
			isMarked = true;
			SpawnMarkedAnimation(transform.position);
			Invoke("DestroyTarget", 2f);
		}

		//if you right click on the asteroid with your mouse while the game is not paused, it will slow the course it has taken towards earth and follow your cursor
		if (Input.GetMouseButton(1) && isOver && !healthBarScript.paused)
		{
			if (homingSpeed > 1f)
			{
				homingSpeed = 0.5f;
			}
			//set the position of the mouse to the mouse position
			mousePosition = Input.mousePosition;
			//adjust this positioning to calculate the world point specifically rather than to the parentage
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			//tell the asteroid to move to the mouse position at a certain speed
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

			//if the audio for the asteroid management is not currently on, turn it on and set the boolean to true
			if (!audioOn)
            {
				audio.Play();
				audioOn = true;
			}
		}

		//if the audio is on and the mouse isn't moving this asteroid anymore pause the audio and set the boolean to false
		if (audioOn && !Input.GetMouseButton(1) && !isOver)
        {
			audio.Pause();
			audioOn = false;
        }
	}

	//set the parent of this asteroid
	public void GravitationalPull(Transform newParent)
    {
		asteroid.transform.SetParent(newParent);
	}

	//set the speed of this asteroid to a speed in correlation to your current game's score
	public void SetHoming()
	{
		homingSpeed = 5f + (scoreScript.score *.001f);
	}

	// Use this for initialization
	void Start () {
		//grab the rigidbody component
		rb = GetComponent<Rigidbody2D>();
		//find the earth game object so we can move towards it
		earth = GameObject.FindWithTag("Earth");
		//find the scoreboard  game object so we can add points to it
		scoreBoard = GameObject.FindWithTag("Score Board");
		//establish the audio source
		audio = GetComponent<AudioSource>();
		//create a luck variable which, depending on the number, might allow for rare and more point-worthy asteroids
		luck = Random.Range(0, 100);
		if (luck > 29 && luck < 40)
        {
			sprite.color = Color.yellow;
			color = "yellow";
			asteroidMiningRate += 4;
			asteroidScoreMax = 800;
        } else if (luck > 90 && luck < 93)
		{
			sprite.color = Color.magenta;
			color = "magenta";
			asteroidMiningRate += 14;
			asteroidScoreMax = 1600;
		}
		else if (luck > 1 && luck< 6)
		{
			sprite.color = new Color(0.67f, 0.82f, 0.97f);
			color = "ice";
			asteroidMiningRate += 5;
			asteroidScoreMax = 900;
		}
	}

	void WaitTime()
	{
		scoreNow = true;
	}

	//this method spawns a floating text and gives score points when you decide to manually destroy asteroids
	void DestroyTarget()
	{
		floatingTextController.CreateFloatingText("+6", transform, false, color);
		scoreScript scoreboard = (scoreScript)scoreBoard.GetComponent(typeof(scoreScript));
		scoreboard.increaseScore(6);
		SpawnDestroyAnimation(transform.position);
		spawnerScript.totalAsteroids--;
		Destroy(gameObject);
	}
}
