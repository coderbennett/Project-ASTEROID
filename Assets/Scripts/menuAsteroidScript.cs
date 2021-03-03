using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAsteroidScript : MonoBehaviour {

	public float speed;
	public float h;
	public float v;

	// Use this for initialization
	void Start () {
		h = Random.Range(-1f, 1f);
		v = Random.Range(-1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y + (v * speed));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "wall")
        {
			h *= -1;
			v *= -1;
		}

		if (collision.tag == "barrier")
		{
			gameObject.transform.position = new Vector2(-0.04f, 5.44f);
		}
	}
}
