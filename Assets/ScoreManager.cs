using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;
    public int score;
    public int highScore;
    public void Awake()
    {
        //singlton instance so that we can access the functions in this script from other scripts
        if (instance == null)
        {
            instance = this;
        }
    }
    
    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void increment()
    {
        score += 1;
        uiManager.instance.currentScore.text = "Score: "+score.ToString();
        if (score >= GameManager.instance.highscore)
        {
            GameManager.instance.isHighScore = true;
            uiManager.instance.isHighScore.text = "High Score! ";
        }
    }
    public void startScoring()
    {
        InvokeRepeating("increment", 0.1f, 0.5f);
    }
    public void stopScoring()
    {
        CancelInvoke("increment");
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("highscore"))
        {
            if (PlayerPrefs.GetInt("highscore") < score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }

        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
