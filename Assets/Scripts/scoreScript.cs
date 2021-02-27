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
		scoreString = score.ToString();
		scoreText.text = scoreString;
	}

	public void increaseScore(int number)
    {
		score += number;
    }
}
