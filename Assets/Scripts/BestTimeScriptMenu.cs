using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeScriptMenu : MonoBehaviour
{

    public static BestTimeScriptMenu instance;

    public float bestTime = 0;
    public float bestTime2 = 0;
    public float bestTimeStory = 0;
    public Text counterText, counterText2, counterTextStory;
    public float seconds, minutes, miliseconds;
    public float seconds2, minutes2, miliseconds2;
    public float secondsStory, minutesStory, milisecondsStory;
    bool wereSavesDeleted = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            updateTimeText();
        }
        if (PlayerPrefs.HasKey("BestTime2"))
        {
            bestTime2 = PlayerPrefs.GetFloat("BestTime2");
            updateTimeText();
        }
        if (PlayerPrefs.HasKey("BestTimeStory"))
        {
            bestTime2 = PlayerPrefs.GetFloat("BestTimeStory");
            updateTimeText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //updateTimeText();
        if (wereSavesDeleted == true)
        {
            bestTime = 0;
            bestTime2 = 0;
            bestTimeStory = 0;
            updateTimeText();
            wereSavesDeleted = false;
        }
    }

    void updateTimeText()
    {
        minutes = (int)(bestTime / 60f);
        seconds = (int)(bestTime % 60f);
        miliseconds = (int)(((bestTime % 60f) * 100) % 100);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");

        minutes2 = (int)(bestTime2 / 60f);
        seconds2 = (int)(bestTime2 % 60f);
        miliseconds2 = (int)(((bestTime2 % 60f) * 100) % 100);
        counterText2.text = minutes2.ToString("00") + ":" + seconds2.ToString("00") + ":" + miliseconds2.ToString("00");

        minutesStory = (int)(bestTimeStory / 60f);
        secondsStory = (int)(bestTimeStory % 60f);
        milisecondsStory = (int)(((bestTimeStory % 60f) * 100) % 100);
        counterTextStory.text = minutesStory.ToString("00") + ":" + secondsStory.ToString("00") + ":" + milisecondsStory.ToString("00");
    }

    public void dumbScoreFlag()
    {
        wereSavesDeleted = true;
    }
}
