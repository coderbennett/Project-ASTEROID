using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	public GameObject asteroid;
	public GameObject destroyAnimation;
	private bool isOver = false;
	public Animator animator;
	public Rigidbody2D rb;
	private Vector3 mousePosition;
	public float moveSpeed = 6f;
	public bool orbitting = false;

	private Transform parent;
	private float distancefromParent;
	private float gDistance = 330;
	private GameObject spawnHub;
	private spawnerScript spawnHubScript;

	public float homingSpeed = 0.5f;

	private GameObject earth;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Earth")
		{
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
		}

		if (collision.tag == "MainCamera")
		{
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

	void Update()
	{
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
		if (Input.GetMouseButtonDown(0) && isOver)
		{
			SpawnDestroyAnimation(transform.position);
			spawnerScript.totalAsteroids--;
			Destroy(gameObject);
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
		}
	}

	public void GravitationalPull(Transform newParent)
    {
		asteroid.transform.SetParent(newParent);
	}

	public void SetHoming()
	{
		homingSpeed = 5f;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		earth = GameObject.FindWithTag("Earth");
	}
}
