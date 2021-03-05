using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoresScript : MonoBehaviour
{

    public Text highscore1;
    public Text highscore2;
    public Text highscore3;
    public Text highscore4;
    public Text highscore5;
    public Text highscore6;
    public Text highscore7;
    public Text highscore8;
    public Text highscore9;
    public Text highscore10;

    // Start is called before the first frame update
    void Start()
    {
        highscore1.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highscore2.text = PlayerPrefs.GetInt("HighScore2", 0).ToString();
        highscore3.text = PlayerPrefs.GetInt("HighScore3", 0).ToString();
        highscore4.text = PlayerPrefs.GetInt("HighScore4", 0).ToString();
        highscore5.text = PlayerPrefs.GetInt("HighScore5", 0).ToString();
        highscore6.text = PlayerPrefs.GetInt("HighScore6", 0).ToString();
        highscore7.text = PlayerPrefs.GetInt("HighScore7", 0).ToString();
        highscore8.text = PlayerPrefs.GetInt("HighScore8", 0).ToString();
        highscore9.text = PlayerPrefs.GetInt("HighScore9", 0).ToString();
        highscore10.text = PlayerPrefs.GetInt("HighScore10", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
