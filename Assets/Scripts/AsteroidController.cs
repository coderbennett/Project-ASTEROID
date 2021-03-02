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
		if (collision.tag == "Earth")
		{
			healthbar = GameObject.FindWithTag("Health Bar");
			healthsymbol = GameObject.FindWithTag("Health Symbol");
			SpawnDestroyAnimation(transform.position);
			healthBarScript healthBar = (healthBarScript)healthbar.GetComponent(typeof(healthBarScript));
			healthBar.healthDamaged();
			healthBarScript healthSymbol = (healthBarScript)healthsymbol.GetComponent(typeof(healthBarScript));
			healthSymbol.healthDamaged();
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		if (collision.tag == "MainCamera")
		{
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		if (collision.tag == "Asteroid")
		{
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		if (collision.tag == "Moon")
		{
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		if (collision.tag == "Gravity")
		{
			parent = collision.transform;
			if (parent.name == "Earth Gravitational Pull" && homingSpeed < 1f)
			{
				orbitting = true;
				gDistance = 1000;
			}
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

	public void SpawnDestroyAnimation(Vector3 position)
	{
		Instantiate(destroyAnimation, position, Quaternion.identity);
	}

	public void SpawnMarkedAnimation(Vector3 position)
	{
		GameObject mark = Instantiate(markAnimation, position, Quaternion.identity);
		mark.transform.SetParent(transform);
	}

	void Update()
	{
		if (scoreNow && orbitting)
		{
			floatingTextController.CreateFloatingText("+" + asteroidMiningRate.ToString(), transform, false, color);
			scoreScript scoreboard = (scoreScript)scoreBoard.GetComponent(typeof(scoreScript));
			scoreboard.increaseScore(asteroidMiningRate);
			asteroidScore += asteroidMiningRate;
			scoreNow = false;
			Invoke("WaitTime", 6f);
		}

		if (orbitting)
		{
			
			GravitationalPull(parent);
			distancefromParent = Vector3.Distance(parent.position, transform.position);
			if (distancefromParent < 0 && distancefromParent < (gDistance * -1))
			{
				asteroid.transform.SetParent(null);
			}
			if (distancefromParent > 0 && distancefromParent > gDistance)
			{
				asteroid.transform.SetParent(null);
			}
		}
		animator.SetBool("isOver", isOver);

		if (asteroidScore > 50 && asteroidLevel == 0)
        {
			asteroidMiningRate += 2;
			asteroidLevel = 1;
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


		if (asteroidScore == asteroidScoreMax)
        {
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}
	}

	//this will track the mouse movement (if it is over the asteroid or not)
	public void OnMouseEnter()
	{
		isOver = true;
	}

	public void OnMouseExit()
	{
		isOver = false;
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards(transform.position, earth.transform.position, homingSpeed);
		if (Input.GetMouseButtonDown(0) && isOver && !isMarked)
		{
			isMarked = true;
			SpawnMarkedAnimation(transform.position);
			Invoke("DestroyTarget", 2f);
		}

		if (Input.GetMouseButton(1) && isOver)
		{
			if (homingSpeed > 1f)
			{
				homingSpeed = 0.5f;
			}
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
			if (!audioOn)
            {
				audio.Play();
				audioOn = true;
			}
		}

		if (audioOn && !Input.GetMouseButton(1) && !isOver)
        {
			audio.Pause();
			audioOn = false;
        }
	}

	public void GravitationalPull(Transform newParent)
    {
		asteroid.transform.SetParent(newParent);
	}

	public void SetHoming()
	{
		homingSpeed = 5f + (scoreScript.score *.001f);
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		earth = GameObject.FindWithTag("Earth");
		scoreBoard = GameObject.FindWithTag("Score Board");
		audio = GetComponent<AudioSource>();
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
