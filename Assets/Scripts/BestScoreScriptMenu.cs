using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScriptMenu : MonoBehaviour
{

    public static BestScoreScriptMenu instance;

    public int bestScore, bestScore2;
    public Text counterText, counterText2;
    public float seconds, minutes, miliseconds;
    public float seconds2, minutes2, miliseconds2;
    float scoreTime, scoreTime2;
    bool wereSavesDeleted = false;

    private void Awake()
    {
        instance = this;
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
    }

    public void dumbScoreFlag()
    {
        wereSavesDeleted = true;
    }


}
