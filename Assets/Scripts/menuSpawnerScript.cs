using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class menuSpawnerScript : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public GameObject point4;
	public GameObject goal1;
	public GameObject goal2;
	public GameObject goal3;
	public GameObject goal4;
	public GameObject asteroid;

	public float spawnTime = 6f;

	private GameObject point;
	private GameObject newAsteroid;
	private int spawner;
	private bool spawn = false;
	private int goal;
	private Transform goalTransform;

	// Use this for initialization
	void Start () {

		spawner = Random.Range(1, 5);
		if (spawner == 1)
		{
			point = point1;
			goalTransform = goal2.transform;
		}
		else if (spawner == 2)
		{
			point = point2;
			goalTransform = goal1.transform;
		}
		else if (spawner == 3)
		{
			point = point3;
			goalTransform = goal4.transform;
		}
		else
		{
			point = point4;
			goalTransform = goal3.transform;
		}
		Invoke("SpawnAsteroid", spawnTime);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (spawn == true)
		{
			spawner = Random.Range(1, 5);
			if (spawner == 1)
			{
				point = point1;
				goalTransform = goal2.transform;
			}
			else if (spawner == 2)
			{
				point = point2;
				goalTransform = goal1.transform;
			}
			else if (spawner == 3)
			{
				point = point3;
				goalTransform = goal4.transform;
			}
			else
			{
				point = point4;
				goalTransform = goal3.transform;
			}
			Invoke("SpawnAsteroid", spawnTime);
			spawn = false;
		}

	}

	void SpawnAsteroid()
	{
		newAsteroid = Instantiate(asteroid, point.transform.position, Quaternion.identity);
		menuAsteroidScript asteroidController = (menuAsteroidScript)newAsteroid.GetComponent(typeof(menuAsteroidScript));
		asteroidController.SetDirection(goalTransform);
	}
}
*/
