using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool gameover,isHighScore;
    public int highscore;
    // Use this for initialization
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start () {

        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = 0;
        }
        gameover = false;
        isHighScore = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStart()
    {

        uiManager.instance.GameStart();
        ScoreManager.instance.startScoring();
        GameObject.Find("Platformspawnner").GetComponent<PlatformSpawnner>().startspwanning();


    }
    public void GameOver()
    {
        uiManager.instance.Gameover();
        ScoreManager.instance.stopScoring();
        gameover = true;
    }
}
