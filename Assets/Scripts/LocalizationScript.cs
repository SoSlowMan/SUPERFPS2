using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationScript : MonoBehaviour
{
    public Text bestTime, bestScore;
    public string language;
    public static LocalizationScript instance;
    public Font rusFont, engFont;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetString("Language");
            if (PlayerPrefs.GetString("Language") == "Русский")
            {
                translateToRussian();
            }
            else
            {
                translateToEnglish();
            }
        }
        else
        {
            PlayerPrefs.SetString("Language", "English");
            translateToEnglish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void translateToEnglish()
    {
        bestTime.text = "Best time: ";
        bestTime.fontSize = 300;
        bestTime.font = engFont;
        bestScore.text = "Best score: ";
        bestScore.fontSize = 300;
        bestScore.font = engFont;
    }

    public void translateToRussian()
    {
        bestTime.text = "Лучшее время: ";
        bestTime.fontSize = 140;
        bestTime.font = rusFont;
        bestScore.text = "Лучший счет: ";
        bestScore.fontSize = 180;
        bestScore.font = rusFont;
    }
}
