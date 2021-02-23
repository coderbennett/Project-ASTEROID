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
		if (totalAsteroids < maxAsteroids)
		{
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
		}

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
		asteroidCount = totalAsteroids;

		if (spawn == true && (totalAsteroids < maxAsteroids))
		{
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
			totalAsteroids++;
			spawn = false;
		}

		if (spawnHoming == true)
		{
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
			totalAsteroids++;
			spawnHoming = false;
		}
	}

	void SpawnAsteroid()
	{
		Instantiate(asteroid, point.transform.position, Quaternion.identity);
		spawn = true;
	}

	void SpawnHomingAsteroid()
	{
		homingAsteroid = Instantiate(asteroid, pointHoming.transform.position, Quaternion.identity);
		AsteroidController asteroidController = (AsteroidController)homingAsteroid.GetComponent(typeof(AsteroidController));
		asteroidController.SetHoming();
		spawnHoming = true;
	}
}
