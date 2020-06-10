using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeLevelScript : MonoBehaviour
{
    public string language;
    public static LocalizeLevelScript instance;
    public Font rusFont, engFont;
    public Text[] Texts;
    public string[] RusStrings;
    public string[] EngStrings;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        createEngList();
        createRusList();

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
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void createRusList()
    {
        RusStrings[0] = "Здоровье:";
        RusStrings[1] = "Патроны:";
        RusStrings[2] = "Урон";
        RusStrings[3] = "Скорость";
        RusStrings[4] = "Время:";
        RusStrings[5] = "Доберись до вулкана как можно быстрее! \n Спасай детей по дороге!";
        RusStrings[6] = "Ты нашел секрет!";
        RusStrings[7] = "ТЫ УМЕР";
        RusStrings[8] = "Еще раз?";
        RusStrings[9] = " Выйти из игры ";
        RusStrings[10] = "Выйти в главное меню";
        RusStrings[11] = "ПОБЕДА! \n Время:";
        RusStrings[12] = "Лучшее время:";
        RusStrings[13] = "Еще раз?";
        RusStrings[14] = " Выйти из игры ";
        RusStrings[15] = "Секретов найдено:";
        RusStrings[16] = "Счет:";
        RusStrings[17] = "Лучший счет:";
        RusStrings[18] = "Выйти в главное меню";
        RusStrings[19] = "Выход открыт!";
        RusStrings[20] = "Секретный главарь появился!";
        RusStrings[21] = "Все дети спасены! \n +5000 очков!";
    }

    void createEngList()
    {
        EngStrings[0] = "Health:";
        EngStrings[1] = "Ammo:";
        EngStrings[2] = "Damage";
        EngStrings[3] = "Speed";
        EngStrings[4] = "Time:";
        EngStrings[5] = "GET TO THE VOLCANO AS FAST AS YOU CAN! \n SAVE THE CHILDREN IF YOU SEE THEM!";
        EngStrings[6] = "YOU'VE DISCOVERED A SECRET!";
        EngStrings[7] = "YOU DIED";
        EngStrings[8] = "Try again?";
        EngStrings[9] = "Return to Windows";
        EngStrings[10] = "Return to Main Menu";
        EngStrings[11] = "YOU WIN! \n Your time:";
        EngStrings[12] = "Your best time:";
        EngStrings[13] = "Try again?";
        EngStrings[14] = "Return to Windows";
        EngStrings[15] = "Secrets found:";
        EngStrings[16] = "SCORE:";
        EngStrings[17] = "Best score:";
        EngStrings[18] = "Return to Main Menu";
        EngStrings[19] = "Exit is opened!";
        EngStrings[20] = "Secret ash leader is here!";
        EngStrings[21] = "All kids are saved! \n +5000 points!";
    }

    public void translateToRussian()
    {
        for (int i = 0; i <= 21; i++)
        {
            Texts[i].text = RusStrings[i];
            Texts[i].font = rusFont;
        }
    }

    public void translateToEnglish()
    {
        for (int i = 0; i <= 21; i++)
        {
            Texts[i].text = EngStrings[i];
            Texts[i].font = engFont;
        }
    }
}
