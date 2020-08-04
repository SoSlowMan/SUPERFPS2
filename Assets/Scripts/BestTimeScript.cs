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
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "jungle":
                time = Time.timeSinceLevelLoad;
                if (PlayerPrefs.HasKey("BestTime") != true) //если рекорда нет в памяти, то записываем результат как рекорд
                {
                    bestTime = time; 
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                }
                else //если рекорд в памяти все-таки есть, то показываем его как лучший
                {
                    bestTime = PlayerPrefs.GetFloat("BestTime");
                }

                if (time < bestTime) //если время сейчас лучше чем рекордное, то меняем
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                }
                updateTimeText();
                counterText = GetComponent<Text>() as Text;
                break;

                //то же самое для второго уровня
            case "dreamcast":
                time = Time.timeSinceLevelLoad;
                if (PlayerPrefs.HasKey("BestTime2") != true) //если рекорда нет в памяти, то записываем результат как рекорд
                {
                    bestTime = time;
                    PlayerPrefs.SetFloat("BestTime2", bestTime);
                }
                else //если рекорд в памяти все-таки есть, то показываем его как лучший
                {
                    bestTime = PlayerPrefs.GetFloat("BestTime2");
                }

                if (time < bestTime) //если время сейчас лучше чем рекордное, то меняем
                {
                    bestTime = time; //для первого запуска
                    PlayerPrefs.SetFloat("BestTime2", bestTime);
                }
                updateTimeText();
                counterText = GetComponent<Text>() as Text;
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
