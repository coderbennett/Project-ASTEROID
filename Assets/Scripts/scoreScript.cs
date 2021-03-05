using System;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

	public static int score = 0;
	public Text highScoreText;
	private string scoreString;
	public Text scoreText;
	private int[] highscores = new int[11];
	private int[] indices = new int[11];
	private bool isScored = false;

	void Start ()
    {
		highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
		highscores[0] = PlayerPrefs.GetInt("HighScore", 0);
		highscores[1] = PlayerPrefs.GetInt("HighScore2", 0);
		highscores[2] = PlayerPrefs.GetInt("HighScore3", 0);
		highscores[3] = PlayerPrefs.GetInt("HighScore4", 0);
		highscores[4] = PlayerPrefs.GetInt("HighScore5", 0);
		highscores[5] = PlayerPrefs.GetInt("HighScore6", 0);
		highscores[6] = PlayerPrefs.GetInt("HighScore7", 0);
		highscores[7] = PlayerPrefs.GetInt("HighScore8", 0);
		highscores[8] = PlayerPrefs.GetInt("HighScore9", 0);
		highscores[9] = PlayerPrefs.GetInt("HighScore10", 0);
	}

	// Update is called once per frame
	void Update () {
		//update the score text according to the score variables
		scoreString = score.ToString();
		scoreText.text = scoreString;

		if (score > PlayerPrefs.GetInt("HighScore", 0))
		{
			highScoreText.text = score.ToString();
		}

		if (healthBarScript.gameover && !isScored)
        {
			highscores[10] = score;
			Array.Sort(highscores);
			PlayerPrefs.SetInt("HighScore", highscores[10]);
			PlayerPrefs.SetInt("HighScore2", highscores[9]);
			PlayerPrefs.SetInt("HighScore3", highscores[8]);
			PlayerPrefs.SetInt("HighScore4", highscores[7]);
			PlayerPrefs.SetInt("HighScore5", highscores[6]);
			PlayerPrefs.SetInt("HighScore6", highscores[5]);
			PlayerPrefs.SetInt("HighScore7", highscores[4]);
			PlayerPrefs.SetInt("HighScore8", highscores[3]);
			PlayerPrefs.SetInt("HighScore9", highscores[2]);
			PlayerPrefs.SetInt("HighScore10", highscores[1]);
			isScored = true;
		}
	}

	//use this method to increase the score
	public void increaseScore(int number)
    {
		if (!healthBarScript.gameover)
        {
			score += number;
		}
    }
}
