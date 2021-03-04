using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

	public static int score = 0;
	private string scoreString;
	public Text scoreText;

	// Update is called once per frame
	void Update () {
		//update the score text according to the score variables
		scoreString = score.ToString();
		scoreText.text = scoreString;
	}

	//use this method to increase the score
	public void increaseScore(int number)
    {
		score += number;
    }
}
