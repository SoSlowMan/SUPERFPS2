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
    public float bestScoreStory = 0;
    public float bestTimeScoreStory = 0;
    public Text counterText, counterText2;
    public float seconds, minutes, miliseconds, secondsStory, minutesStory, milisecondsStory;
    public string currentLevel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //counterText = GetComponent<Text>() as Text;
        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "jungle":
                score = PlayerController.instance.score;
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    if (PlayerPrefs.HasKey("BestScoreStory1") != true || (PlayerPrefs.HasKey("ScoreTimeStory1") != true)) //если сохранений рекордов нет, то просто записываем получившийся результат
                    {
                        bestScore = score;
                        PlayerPrefs.SetInt("BestScoreStory1", bestScore);
                        scoreTime = Time.timeSinceLevelLoad;
                        PlayerPrefs.SetFloat("ScoreTimeStory1", scoreTime);
                    }
                    else //если сохранения есть, то показываем их
                    {
                        bestScore = PlayerPrefs.GetInt("BestScoreStory1");
                        scoreTime = PlayerPrefs.GetFloat("ScoreTimeStory1");
                    }

                    if (score >= bestScore) //если полученные очки лучше рекордов, то записываем и показываем новый рекорд
                    {
                        bestScore = score;
                        PlayerPrefs.SetInt("bestScoreStory1", bestScore);
                        scoreTime = Time.timeSinceLevelLoad;
                        PlayerPrefs.SetFloat("ScoreTimeStory1", scoreTime);
                    }

                    PlayerPrefs.SetFloat("ScoreTimeStory1", scoreTime); //записываю результат первого левела
                    PlayerPrefs.SetFloat("ScoreStory1", score);
                }
                else
                {
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
                }
                updateScoreText();
                //counterText = GetComponent<Text>() as Text;
                break;

                //то же самое для второго уровня
            case "dreamcast":
                score = PlayerController.instance.score;
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    if (PlayerPrefs.HasKey("BestScoreStory2") != true || (PlayerPrefs.HasKey("ScoreTimeStory2") != true)) //если сохранений рекордов нет, то просто записываем получившийся результат
                    {
                        bestScore = score;
                        PlayerPrefs.SetInt("BestScoreStory2", bestScore);
                        scoreTime = Time.timeSinceLevelLoad;
                        PlayerPrefs.SetFloat("ScoreTimeStory2", scoreTime);
                    }
                    else //если сохранения есть, то показываем их
                    {
                        bestScore = PlayerPrefs.GetInt("BestScoreStory2");
                        scoreTime = PlayerPrefs.GetFloat("ScoreTimeStory2");
                    }

                    if (score >= bestScore) //если полученные очки лучше рекордов, то записываем и показываем новый рекорд
                    {
                        bestScore = score;
                        PlayerPrefs.SetInt("bestScoreStory2", bestScore);
                        scoreTime = Time.timeSinceLevelLoad;
                        PlayerPrefs.SetFloat("ScoreTimeStory2", scoreTime);
                    }

                    PlayerPrefs.SetFloat("ScoreTimeStory2", scoreTime); //записываю результат первого левела
                    PlayerPrefs.SetFloat("ScoreStory2", score);

                    if (PlayerPrefs.HasKey("BestScoreStory") != true || PlayerPrefs.HasKey("BestTimeScoreStory") != true) //если рекорда нет в памяти, то записываем результат как рекорд
                    {
                        bestTimeScoreStory = PlayerPrefs.GetFloat("ScoreTimeStory1") + PlayerPrefs.GetFloat("ScoreTimeStory2");
                        bestScoreStory = PlayerPrefs.GetFloat("ScoreStory1") + PlayerPrefs.GetFloat("ScoreStory2");
                        PlayerPrefs.SetFloat("BestScoreStory", bestScoreStory);
                        PlayerPrefs.SetFloat("BestTimeScoreStory", bestTimeScoreStory);
                    }
                    else
                    {
                        bestTimeScoreStory = PlayerPrefs.GetFloat("BestTimeScoreStory");
                        bestScoreStory = PlayerPrefs.GetFloat("BestScoreStory");
                    }

                    if ((PlayerPrefs.GetFloat("ScoreStory1") + PlayerPrefs.GetFloat("ScoreStory2")) > PlayerPrefs.GetFloat("BestScoreStory"))
                    {
                        bestTimeScoreStory = PlayerPrefs.GetFloat("ScoreTimeStory1") + PlayerPrefs.GetFloat("ScoreTimeStory2");
                        bestScoreStory = PlayerPrefs.GetFloat("ScoreStory1") + PlayerPrefs.GetFloat("ScoreStory2");
                        PlayerPrefs.SetFloat("BestScoreStory", bestScoreStory);
                        PlayerPrefs.SetFloat("BestTimeScoreStory", bestTimeScoreStory);
                    }
                }
                else
                {
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
                }
                                
                updateScoreText();
                //counterText = GetComponent<Text>() as Text;
                break;
        }
    }

    void updateScoreText()
    {
        minutes = (int)(scoreTime / 60f);
        seconds = (int)(scoreTime % 60f);
        miliseconds = (int)(((scoreTime % 60f) * 100) % 100);
        counterText.text = bestScore.ToString("0") + "/" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
        if (PlayerPrefs.HasKey("StoryMode"))
        {
            minutesStory = (int)(bestTimeScoreStory / 60f);
            secondsStory = (int)(bestTimeScoreStory % 60f);
            milisecondsStory = (int)(((bestTimeScoreStory % 60f) * 100) % 100);
            counterText2.text = bestScoreStory.ToString("0") + "/" + minutesStory.ToString("00") + ":" + secondsStory.ToString("00") + ":" + milisecondsStory.ToString("00");
        } 
    }
}
