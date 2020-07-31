using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestScoreScript : MonoBehaviour
{
    public static BestScoreScript instance;

    int score;
    float scoreTime = 0;
    public int bestScore = 0;
    public Text counterText;
    public GameObject successDeletionText;
    public float seconds, minutes, miliseconds;
    public string currentLevel;

    private void Awake()
    {
        instance = this;
        switch (currentLevel)
        {
            case "jungle":
                if (PlayerPrefs.HasKey("BestScore") || (PlayerPrefs.HasKey("ScoreTime")))
                {
                    bestScore = PlayerPrefs.GetInt("BestScore");
                    scoreTime = PlayerPrefs.GetFloat("ScoreTime");
                    updateScoreText();
                }
                break;
            case "dreamcast":
                if (PlayerPrefs.HasKey("BestScore2") || (PlayerPrefs.HasKey("ScoreTime2")))
                {
                    bestScore = PlayerPrefs.GetInt("BestScore2");
                    scoreTime = PlayerPrefs.GetFloat("ScoreTime2");
                    updateScoreText();
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "jungle":
                score = PlayerController.instance.score;
                if ((bestScore == 0) || (score >= bestScore))
                {
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime", scoreTime);
                    updateScoreText();
                }
                //successDeletionText.SetActive(false);
                counterText = GetComponent<Text>() as Text;
                break;
            case "dreamcast":
                score = PlayerController.instance.score;
                if ((bestScore == 0) || (score >= bestScore))
                {
                    //для первого запуска
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore2", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime2", scoreTime);
                    updateScoreText();
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateScoreText()
    {
        minutes = (int)(scoreTime / 60f);
        seconds = (int)(scoreTime % 60f);
        miliseconds = (int)(((scoreTime % 60f) * 100) % 100);
        counterText.text = bestScore.ToString("0") + "/" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
