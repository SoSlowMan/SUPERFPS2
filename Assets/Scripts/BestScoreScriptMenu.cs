using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScriptMenu : MonoBehaviour
{

    public static BestScoreScriptMenu instance;

    public int bestScore, bestScore2, bestScoreStory;
    public Text counterText, counterText2, counterTextStory;
    public float seconds, minutes, miliseconds;
    public float seconds2, minutes2, miliseconds2;
    public float secondsStory, minutesStory, milisecondsStory;
    float scoreTime, scoreTime2, bestTimeScoreStory;
    bool wereSavesDeleted = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore") || (PlayerPrefs.HasKey("ScoreTime")))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            scoreTime = PlayerPrefs.GetFloat("ScoreTime");
            updateScoreText();
        }
        if (PlayerPrefs.HasKey("BestScore2") || (PlayerPrefs.HasKey("ScoreTime2")))
        {
            bestScore2 = PlayerPrefs.GetInt("BestScore2");
            scoreTime2 = PlayerPrefs.GetFloat("ScoreTime2");
            updateScoreText();
        }
        if (PlayerPrefs.HasKey("BestScoreStory") || (PlayerPrefs.HasKey("BestTimeScoreStory")))
        {
            bestScore2 = PlayerPrefs.GetInt("BestScoreStory");
            scoreTime2 = PlayerPrefs.GetFloat("BestTimeScoreStory");
            updateScoreText();
        }
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (wereSavesDeleted == true)
        {
            bestScore = 0;
            bestScore2 = 0;
            scoreTime = 0;
            scoreTime2 = 0;
            bestTimeScoreStory = 0;
            bestScoreStory = 0;
            updateScoreText();
            wereSavesDeleted = false;
        }
    }

    void updateScoreText()
    {
        minutes = (int)(scoreTime / 60f);
        seconds = (int)(scoreTime % 60f);
        miliseconds = (int)(((scoreTime % 60f) * 100) % 100);
        counterText.text = bestScore.ToString("0") + "/" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");

        minutes2 = (int)(scoreTime2 / 60f);
        seconds2 = (int)(scoreTime2 % 60f);
        miliseconds2 = (int)(((scoreTime2 % 60f) * 100) % 100);
        counterText2.text = bestScore2.ToString("0") + "/" + minutes2.ToString("00") + ":" + seconds2.ToString("00") + ":" + miliseconds2.ToString("00");

        minutesStory = (int)(bestTimeScoreStory / 60f);
        secondsStory = (int)(bestTimeScoreStory % 60f);
        milisecondsStory = (int)(((bestTimeScoreStory % 60f) * 100) % 100);
        counterTextStory.text = bestScoreStory.ToString("0") + "/" + minutesStory.ToString("00") + ":" + secondsStory.ToString("00") + ":" + milisecondsStory.ToString("00");
    }

    public void dumbScoreFlag()
    {
        wereSavesDeleted = true;
    }
}
