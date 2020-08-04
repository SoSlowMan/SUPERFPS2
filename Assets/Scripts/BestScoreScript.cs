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
    public float seconds, minutes, miliseconds;
    public string currentLevel;

    private void Awake()
    {
        instance = this;
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
                if (PlayerPrefs.HasKey("BestScore") != true || (PlayerPrefs.HasKey("ScoreTime") != true)) //если сохранений рекордов нет, то просто записываем получившийся результат
                {
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime", scoreTime);
                }
                else //если сохранения есть, то показываем их
                {
                    bestScore = PlayerPrefs.GetInt("BestScore");
                    scoreTime = PlayerPrefs.GetFloat("ScoreTime");                  
                }

                if (score >= bestScore) //если полученные очки лучше рекордов, то записываем и показываем новый рекорд
                {
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime", scoreTime);
                }
                updateScoreText();
                counterText = GetComponent<Text>() as Text;
                break;

                //то же самое для второго уровня
            case "dreamcast":
                score = PlayerController.instance.score;
                if (PlayerPrefs.HasKey("BestScore2") != true || (PlayerPrefs.HasKey("ScoreTime2") != true)) //если сохранений рекордов нет, то просто записываем получившийся результат
                {
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore2", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime2", scoreTime);
                }
                else //если сохранения есть, то показываем их
                {
                    bestScore = PlayerPrefs.GetInt("BestScore2");
                    scoreTime = PlayerPrefs.GetFloat("ScoreTime2");
                }

                if (score >= bestScore) //если полученные очки лучше рекордов, то записываем и показываем новый рекорд
                {
                    bestScore = score;
                    PlayerPrefs.SetInt("BestScore2", bestScore);
                    scoreTime = Time.timeSinceLevelLoad;
                    PlayerPrefs.SetFloat("ScoreTime2", scoreTime);
                }
                updateScoreText();
                counterText = GetComponent<Text>() as Text;
                break;
        }
    }

    void updateScoreText()
    {
        minutes = (int)(scoreTime / 60f);
        seconds = (int)(scoreTime % 60f);
        miliseconds = (int)(((scoreTime % 60f) * 100) % 100);
        counterText.text = bestScore.ToString("0") + "/" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
