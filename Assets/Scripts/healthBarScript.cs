using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour {

	public Animator animator;

	public int health = 9;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("health", health);
	}

	public void healthDamaged()
    {
		health--;
    }
}
