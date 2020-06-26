using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeScriptMenu : MonoBehaviour
{

    public static BestTimeScriptMenu instance;

    public float bestTime = 0;
    public Text counterText;
    public float seconds, minutes, miliseconds;
    bool wereSavesDeleted = false;

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
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            updateTimeText();
        }
        else
        {

        }
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        //updateTimeText();
        if (wereSavesDeleted == true)
        {
            bestTime = 0;
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
    }

    public void dumbScoreFlag()
    {
        wereSavesDeleted = true;
    }
}
