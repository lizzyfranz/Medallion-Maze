using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Text highscoreText;
    private const string HIGHSCORE = "highscore";

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(HIGHSCORE))
        {
            PlayerPrefs.SetInt(HIGHSCORE, 0);
        }

        highscoreText.text = "High Score: " + PlayerPrefs.GetInt(HIGHSCORE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MazeScene");
    }
}
