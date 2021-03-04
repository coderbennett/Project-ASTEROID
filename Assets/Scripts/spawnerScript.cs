using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour {

	public static int totalAsteroids;
	public GameObject earth;

	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public GameObject point4;
	public GameObject point5;
	public GameObject point6;
	public GameObject point7;
	public GameObject point8;
	public GameObject point9;
	public GameObject asteroid;
	public int asteroidCount;
	public int maxAsteroids = 30;
	public float spawnTime = 6f;

	private GameObject homingAsteroid;
	private GameObject pointHoming;
	private int spawnerHoming;
	private bool spawnHoming = false;

	private GameObject point;
	private int spawner;
	private bool spawn = false;

	// Use this for initialization
	void Start ()
	{
		//set which spawn point will spawn a slow and less deadly asteroid
		spawner = Random.Range(1, 5);
		if (spawner == 1)
		{
			point = point1;
		}
		else if (spawner == 2)
		{
			point = point2;
		}
		else if (spawner == 3)
		{
			point = point3;
		}
		else
		{
			point = point4;
		}
		Invoke("SpawnAsteroid", spawnTime);

		//set which homing spawn point will spawn a faster and more deadly asteroid
		spawnerHoming = Random.Range(5, 10);
		if (spawnerHoming == 5)
		{
			pointHoming = point5;
		}
		else if (spawnerHoming == 6)
		{
			pointHoming = point6;
		}
		else if (spawnerHoming == 7)
		{
			pointHoming = point7;
		}
		else if (spawnerHoming == 8)
		{
			pointHoming = point8;
		}
		else
		{
			pointHoming = point9;
		}
		Invoke("SpawnHomingAsteroid", spawnTime);
		spawnHoming = false;
	}
	
	// Update is called once per frame
	void Update () {
		//set the asteroid count to the total number of asteroids on the map
		asteroidCount = totalAsteroids;

		//if it is time to spawn an asteroid and we haven't exceeded the maximum allowed asteroids on the map, then proceed
		if (spawn == true && (totalAsteroids < maxAsteroids))
		{
			//set which spawner we're going to be using
			spawner = Random.Range(1, 5);
			if (spawner == 1)
			{
				point = point1;
			}
			else if (spawner == 2)
			{
				point = point2;
			}
			else if (spawner == 3)
			{
				point = point3;
			}
			else
			{
				point = point4;
			}
			Invoke("SpawnAsteroid", spawnTime);
			//increase the counter for the total number of asteroids we have
			totalAsteroids++;
			//set the spawner false since we just invoked the method (which the method itself will restart this process)
			spawn = false;
		}

		if (spawnHoming == true)
		{
			//set which of the homing spawners we will be using
			spawnerHoming = Random.Range(5, 10);
			if (spawnerHoming == 5)
			{
				pointHoming = point5;
			}
			else if (spawnerHoming == 6)
			{
				pointHoming = point6;
			}
			else if (spawnerHoming == 7)
			{
				pointHoming = point7;
			}
			else if (spawnerHoming == 8)
			{
				pointHoming = point8;
			}
			else
			{
				pointHoming = point9;
			}
			Invoke("SpawnHomingAsteroid", spawnTime);
			//increase the counter for the total number of asteroids we have
			totalAsteroids++;
			//set the spawner false since we just invoked the method (which the method itself will restart this process)
			spawnHoming = false;
		}
	}

	//this method will spawn an asteroid if the game is not paused
	void SpawnAsteroid()
	{
		if (!healthBarScript.paused)
		{
			Instantiate(asteroid, point.transform.position, Quaternion.identity);
		}
		spawn = true;
	}

	//this method will spawn an asteroid if the game is not paused
	void SpawnHomingAsteroid()
	{
		if (!healthBarScript.paused)
		{
			homingAsteroid = Instantiate(asteroid, pointHoming.transform.position, Quaternion.identity);
			AsteroidController asteroidController = (AsteroidController)homingAsteroid.GetComponent(typeof(AsteroidController));
			asteroidController.SetHoming();
		}
		spawnHoming = true;
	}
}
