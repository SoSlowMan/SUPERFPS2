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
    public GameObject successDeletionText;

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            updateTimeText();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "tutor")
        {
            time = Time.timeSinceLevelLoad; //время со старта лвла
            if (bestTime == 0)
            {
                bestTime = time; //для первого запуска
                PlayerPrefs.SetFloat("BestTime", bestTime);
            }
            //successDeletionText.SetActive(false); //текст дающий понять что хайскор был удален, ставлю в фолс чтобы не светился если я текст не удалил
            counterText = GetComponent<Text>() as Text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "tutor")
        {
            if (time <= bestTime)
            {
                bestTime = time;

                PlayerPrefs.SetFloat("BestTime", bestTime);
            }

            updateTimeText();
        }
            
    }

    /*void newBestTime()
    {
        bestTime = time;
    }*/

    void updateTimeText()
    {
        minutes = (int)(bestTime / 60f);
        seconds = (int)(bestTime % 60f);
        miliseconds = (int)(((bestTime % 60f) * 100) % 100);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
