using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAsteroidScript : MonoBehaviour {

	public float speed;
	public float h;
	public float v;

	// Use this for initialization
	void Start () {
		//set random horizontal and vertical numbers
		h = Random.Range(-1f, 1f);
		v = Random.Range(-1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//move the asteroid by the h & v & speed variables
		gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y + (v * speed));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if the asteroid collides with an object tagged as a wall, the asteroid will bounce and move in the opposite direction
		if (collision.tag == "wall")
        {
			h *= -1;
			v *= -1;
		}

		//if the asteroid somehow escapes the walls, the final hope to keep them on screen is hitting an outer barrier which teleports them back in the walls
		if (collision.tag == "barrier")
		{
			gameObject.transform.position = new Vector2(-0.04f, 5.44f);
		}
	}
}
