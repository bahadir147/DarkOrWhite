using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();

            }
            return GameManager.instance;
        }
    }



    int score = 0;
    public TextMeshProUGUI CurrentScoreTextTMPro;
    public TextMeshProUGUI BestScoreTextTMPro;


    public GameObject StartFadeInObj;

    public static int BeforeScore = 0;

    public Button ContinueButton;


    static int PlayCount;
    public string PlayStoreURL;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;


        int inverse = PlayerPrefs.GetInt("GameKey", 0);

        if (inverse == 1)
            Revert();

    }

    private void Revert()
    {
        ObstacleManager.Instance.revertColor = true;
        CameraBGManager.Instance.startColor = Color.black;
        CameraBGManager.Instance.targetColor = Color.white;
    }

    public void addScore()
    {
        score++;
        //CurrentScoreTextTMPro.text = score.ToString();

        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
            //BestScoreTextTMPro.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
    }
    public void Restart()
    {
        BeforeScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RateUs()
    {
        Application.OpenURL(PlayStoreURL);
    }

}
