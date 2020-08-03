using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestTimeScript : MonoBehaviour
{

    public static BestTimeScript instance;

    public float time;
    public float bestTime = 0;
    public float bestTimeStory = 0;
    public Text counterText;
    public float seconds, minutes, miliseconds;
    public string currentLevel;

    private void Awake()
    {
        instance = this;
        switch (currentLevel)
        {
            case "jungle":
                if (PlayerPrefs.HasKey("BestTime") && PlayerPrefs.HasKey("StoryMode") != true)
                {
                    bestTime = PlayerPrefs.GetFloat("BestTime");
                    updateTimeText();
                }
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    if (PlayerPrefs.HasKey("BestTimeStory1"))
                    {
                        bestTime = PlayerPrefs.GetFloat("BestTimeStory1");
                        updateTimeText();
                    }
                }
                updateTimeText();
                break;
            case "dreamcast":
                if (PlayerPrefs.HasKey("BestTime2") && PlayerPrefs.HasKey("StoryMode") != true)
                {
                    bestTime = PlayerPrefs.GetFloat("BestTime2");
                    updateTimeText();
                }
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    if (PlayerPrefs.HasKey("BestTimeStory2"))
                    {
                        bestTime = PlayerPrefs.GetFloat("BestTimeStory2");
                        updateTimeText();
                    }
                }
                updateTimeText();
                break;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "jungle":
                time = Time.timeSinceLevelLoad; //время со старта лвла
                if (bestTime == 0 && PlayerPrefs.HasKey("StoryMode") != true)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                }
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    if (PlayerPrefs.HasKey("BestTimeStory1"))
                    {
                        bestTime = PlayerPrefs.GetFloat("BestTimeStory1");
                        updateTimeText();
                    }
                }
                updateTimeText();
                counterText = GetComponent<Text>() as Text;
                break;
            case "dreamcast":
                time = Time.timeSinceLevelLoad; //время со старта лвла
                if (bestTime == 0 && PlayerPrefs.HasKey("StoryMode") != true)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime2", bestTime);
                }
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    if (PlayerPrefs.HasKey("BestTimeStory2"))
                    {
                        bestTime = PlayerPrefs.GetFloat("BestTimeStory2");
                        updateTimeText();
                    }
                    if (PlayerPrefs.HasKey("BestTimeStory"))
                    {
                        bestTimeStory = PlayerPrefs.GetFloat("BestTimeStory");
                        updateTimeText();
                    }
                    else
                    {
                        bestTimeStory = PlayerPrefs.GetFloat("TimeStory1") + PlayerPrefs.GetFloat("TimeStory2"); // для записи первого рекорда для всего режима
                    }
                }
                updateTimeText();
                counterText = GetComponent<Text>() as Text;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentLevel)
        {
            case "jungle":
                time = Time.timeSinceLevelLoad; //время со старта лвла
                if (time <= bestTime && PlayerPrefs.HasKey("StoryMode") != true)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                }
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    PlayerPrefs.SetFloat("TimeStory1", time); //записываю результат пробежки первого уровня, чтобы потом получить лучший по истории
                    if(time <= bestTime)
                    {
                        bestTime = time; //записываю резултат в лучший, если он лучший
                        PlayerPrefs.SetFloat("BestTimeStory1", bestTime);
                    }
                }
                updateTimeText();
                break;
            case "dreamcast":
                time = Time.timeSinceLevelLoad; //время со старта лвла
                if (time <= bestTime && PlayerPrefs.HasKey("StoryMode") != true)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime2", bestTime);
                }
                if (PlayerPrefs.HasKey("StoryMode"))
                {
                    PlayerPrefs.SetFloat("TimeStory2", time); //записываю результат пробежки второго уровня, чтобы потом получить лучший по истории
                    if (time <= bestTime)
                    {
                        bestTime = time; //записываю резултат в лучший, если он лучший
                        PlayerPrefs.SetFloat("BestTimeStory2", bestTime);
                    }
                    //записывать рекорды всей истории тута
                    if (PlayerPrefs.GetFloat("BestTimeStory") >= (PlayerPrefs.GetFloat("TimeStory1") + PlayerPrefs.GetFloat("TimeStory2")))
                    {
                        bestTimeStory = PlayerPrefs.GetFloat("TimeStory1") + PlayerPrefs.GetFloat("TimeStory2");
                        PlayerPrefs.SetFloat("BestTimeStory", bestTimeStory);
                    }

                }
                updateTimeText();
                break;
        }

    }

    void updateTimeText()
    {
        minutes = (int)(bestTime / 60f);
        seconds = (int)(bestTime % 60f);
        miliseconds = (int)(((bestTime % 60f) * 100) % 100);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
