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
    public Text counterText;
    public float seconds, minutes, miliseconds;
    public string currentLevel;

    private void Awake()
    {
        instance = this;
        switch (currentLevel)
        {
            case "jungle":
                if (PlayerPrefs.HasKey("BestTime"))
                {
                    bestTime = PlayerPrefs.GetInt("BestTime");
                    updateTimeText();
                }
                break;
            case "dreamcast":
                if (PlayerPrefs.HasKey("BestTime2"))
                {
                    bestTime = PlayerPrefs.GetInt("BestTime2");
                    updateTimeText();
                }
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
                if (bestTime == 0)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                }
                counterText = GetComponent<Text>() as Text;
                break;
            case "dreamcast":
                time = Time.timeSinceLevelLoad; //время со старта лвла
                if (bestTime == 0)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime2", bestTime);
                }
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
                if (time <= bestTime)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                }
                updateTimeText();
                break;
            case "dreamcast":
                time = Time.timeSinceLevelLoad; //время со старта лвла
                if (time <= bestTime)
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime2", bestTime);
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
