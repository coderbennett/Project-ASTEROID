using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	public GameObject asteroid;
	public GameObject destroyAnimation;
	private bool isOver = false;
	public Animator animator;
	private Vector3 mousePosition;
	public float moveSpeed = 6f;
	public bool orbitting = false;
	public GameObject earth;
	public GameObject moon;
	private Transform parent;
	public spawnerScript spawnHub;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Earth")
		{
			SpawnDestroyAnimation(transform.position);
			Destroy(gameObject);
        }

		if (collision.tag == "Gravity" && collision.name == "Earth Gravitational Pull")
        {
			orbitting = true;
			parent = earth.transform;
		}

		if (collision.tag == "Gravity" && collision.name == "Moon Gravitational Pull")
		{
			orbitting = true;
			parent = moon.transform;
		}
	}

	public void SpawnDestroyAnimation(Vector3 position)
	{
		Instantiate(destroyAnimation, position, Quaternion.identity);
	}

	void Update()
	{
		animator.SetBool("isOver", isOver);
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
		if (Input.GetMouseButtonDown(0) && isOver)
		{
			SpawnDestroyAnimation(transform.position);
			Destroy(gameObject);
		}

		if (Input.GetMouseButton(1) && isOver)
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
		}

		if (orbitting == true)
        {
			GravitationalPull(parent);
        }
	}

	public void GravitationalPull(Transform newParent)
    {
		asteroid.transform.SetParent(newParent);
    }

	// Use this for initialization
	void Start () {
	}
}
