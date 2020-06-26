using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScriptMenu : MonoBehaviour
{

    public static BestScoreScriptMenu instance;

    public int bestScore;
    public Text counterText;
    public float seconds, minutes, miliseconds;
    float scoreTime;
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
        else
        {

        }
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (wereSavesDeleted == true)
        {
            bestScore = 0;
            scoreTime = 0;
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
    }

    public void dumbScoreFlag()
    {
        wereSavesDeleted = true;
    }


}
