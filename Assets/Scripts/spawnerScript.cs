using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public GameObject point4;
	public GameObject asteroid;
	public int totalAsteroids;
	public float spawnTime = 6f;
	private bool spawn = false;

	private GameObject point;
	private int spawner;

	// Use this for initialization
	void Start ()
	{
		spawner = Random.Range(1, 5);
		if (spawner == 1 && totalAsteroids < 20)
        {
			point = point1;
        } else if (spawner == 2){
			point = point2;
        } else if (spawner == 3)
        {
			point = point3;
        } else
        {
			point = point4;
        }
		Invoke("SpawnAsteroid", spawnTime);
		totalAsteroids++;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawn == true)
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
			spawn = false;
		}
	}

	void SpawnAsteroid()
	{
		Instantiate(asteroid, point.transform.position, Quaternion.identity);
		spawn = true;
	}

	void asteroidDestroyed()
    {
	}
}
