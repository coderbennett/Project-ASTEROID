using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

	public int score = 0;
	private string scoreString;
	public Text scoreText;

	private bool scoreNow = true;

	// Update is called once per frame
	void Update () {
		scoreString = score.ToString();
		scoreText.text = scoreString;
		if (scoreNow)
		{
			Invoke("autoScore", 10f);
			scoreNow = false;
		}

	}

	public void increaseScore(int number)
    {
		score += number;
    }

	void autoScore()
    {
		score += 10;
		scoreNow = true;
    }
}
