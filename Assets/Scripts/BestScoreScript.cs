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

    private void Awake()
    {
        instance = this;
        //scoreTime = Time.timeSinceLevelLoad;
        if (PlayerPrefs.HasKey("BestScore") || (PlayerPrefs.HasKey("ScoreTime")))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            scoreTime = PlayerPrefs.GetFloat("ScoreTime");
            updateScoreText();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "tutor")
        {
            score = PlayerController.instance.score;
            if (bestScore == 0)
            {
                //для первого запуска
                bestScore = score; 
                PlayerPrefs.SetInt("BestScore", bestScore);
                scoreTime = Time.timeSinceLevelLoad;
                PlayerPrefs.SetFloat("ScoreTime", scoreTime);
                updateScoreText();
                //scoreTime = PlayerPrefs.GetFloat("ScoreTime");
            }
            else if (PlayerPrefs.HasKey("BestScore") || (PlayerPrefs.HasKey("ScoreTime")))
            {
                if (score >= bestScore)
                {
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime", scoreTime);
                    //scoreTime = PlayerPrefs.GetFloat("ScoreTime");
                    //bestScore = PlayerPrefs.GetInt("BestScore");
                }
                updateScoreText();
            }
            //successDeletionText.SetActive(false);
            counterText = GetComponent<Text>() as Text;
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (SceneManager.GetActiveScene().name != "tutor")
        {
            if (score >= bestScore)
            {
                bestScore = score;
                PlayerPrefs.SetInt("BestScore", bestScore);
                //PlayerPrefs.SetFloat("ScoreTime", scoreTime);
            }

            updateScoreText();
        }*/
    }

    void updateScoreText()
    {
        minutes = (int)(scoreTime / 60f);
        seconds = (int)(scoreTime % 60f);
        miliseconds = (int)(((scoreTime % 60f) * 100) % 100);
        counterText.text = bestScore.ToString("0") + "/" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
