﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MSMScript : MonoBehaviour
{
    int score = 0;
    public Text scoreText;

    public PlayerScript playerPrototype;
    private const string HIGHSCORE = "highscore";
    private static MSMScript _instance = null;
    public static MSMScript Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //see if the user would like to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int highscore = 0;

            if (PlayerPrefs.HasKey(HIGHSCORE))
            {
                highscore = PlayerPrefs.GetInt(HIGHSCORE);
            }

            if (highscore < score)
            {
                PlayerPrefs.SetInt(HIGHSCORE, score);
            }
            Application.Quit();
        }
    }

    public void HitCoin()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void PlayerDied()
    {
        if(score > 0)
        {
            score--;
        }
        scoreText.text = "Score: " + score;
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrototype, new Vector2(-7, -4.5f), Quaternion.identity);
    }

    public void FinishGame()
    {
        int highscore = 0;

        if (PlayerPrefs.HasKey(HIGHSCORE))
        {
            highscore = PlayerPrefs.GetInt(HIGHSCORE);
        }

        if (highscore < score)
        {
            PlayerPrefs.SetInt(HIGHSCORE, score);
        }

        SceneManager.LoadScene("OpeningScene");
    }
}
