using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class uiManager : MonoBehaviour {
    public GameObject zigzagpanel,taptoplay, gameoverpanel,scoreWhilePlaying;
    public Text score, highscore1, highscore2,currentScore,isHighScore;
    public static uiManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }

    }
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("highscore")){
            highscore2.text = "High Score :  " + PlayerPrefs.GetInt("highscore").ToString();

        }
        else
        {
            highscore2.text = "High Score : 0 :) "; 
        }
    }
	public void GameStart()
    {
        //when the gae starts 
        // It shouldnt show the tap to play text so...
        taptoplay.SetActive(false);
        //when the gamestart functon is called the panel up animation  is called from zigzagpanel
        zigzagpanel.GetComponent<Animator>().Play("panelup");
        scoreWhilePlaying.SetActive(true);
        scoreWhilePlaying.GetComponent<Animator>().Play("ScoreCardIn");

    }
    public void GamePlay()
    {


    }
    public void GamePause()
    {

    }
    public void GameResume()
    {

    }

    public void Gameover()
    {
        scoreWhilePlaying.GetComponent<Animator>().Play("ScoreCardOut");
        gameoverpanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore1.text = PlayerPrefs.GetInt("highscore").ToString();
    }
    public void Restart()
    {

        SceneManager.LoadScene(0);

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)&& (GameManager.instance.gameover)){
            SceneManager.LoadScene(0);
        }
        else
        {

        }
	}
}
