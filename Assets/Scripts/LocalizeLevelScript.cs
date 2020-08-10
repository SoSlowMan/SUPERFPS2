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
        RusStrings[10] = " Выйти в главное меню ";
        RusStrings[11] = " ПОБЕДА!\nВремя:";
        RusStrings[12] = "Лучшее время:";
        RusStrings[13] = "Еще раз?";
        RusStrings[14] = " Выйти из игры ";
        RusStrings[15] = "Секретов найдено:";
        RusStrings[16] = "Счет:";
        RusStrings[17] = "Лучший счет:";
        RusStrings[18] = " Выйти в главное меню ";
        RusStrings[19] = "Выход открыт!";
        RusStrings[20] = "Секретный главарь появился!";
        RusStrings[21] = "Все дети спасены! \n +2 к урону и +0.2 к скорости!";
        RusStrings[22] = "Детей спасено:";
        RusStrings[23] = "Врагов уничтожено:";
        RusStrings[24] = "АПОКАЛИПСИС НАЧАЛСЯ";
        RusStrings[25] = "ЛЮДИ ПЕПЛА УБИЛИ ТЕБЯ";
        RusStrings[26] = "На следующий уровень";
        RusStrings[27] = "ПОБЕДА!";
        RusStrings[28] = "На этом уровне";
        RusStrings[29] = "Время:";
        RusStrings[30] = "Лучшее время:";
        RusStrings[31] = "Счет:";
        RusStrings[32] = "Лучший счет:";
        RusStrings[33] = "В режиме истории";
        RusStrings[34] = "Лучший счет:";
        RusStrings[35] = "Еще раз?";
        RusStrings[36] = " Выйти из игры ";
        RusStrings[37] = " Выйти в главное меню ";
        RusStrings[38] = "Секретов найдено:";
        RusStrings[39] = "Детей спасено:";
        RusStrings[40] = "Врагов уничтожено:";
        RusStrings[41] = "ПОБЕДА!";
        RusStrings[42] = "На этом уровне";
        RusStrings[43] = "Время:";
        RusStrings[44] = "Лучшее время:";
        RusStrings[45] = "Счет:";
        RusStrings[46] = "Лучший счет:";
        RusStrings[47] = "В режиме истории";
        RusStrings[48] = "Время:";
        RusStrings[49] = "Лучшее время:";
        RusStrings[50] = "Счет:";
        RusStrings[51] = "Лучший счет:";
        RusStrings[52] = "Еще раз?";
        RusStrings[53] = "На следующий уровень";
        RusStrings[54] = "Выйти из игры";
        RusStrings[55] = "Выйти в главное меню";
        RusStrings[56] = "Секретов найдено:";
        RusStrings[57] = "Детей спасено:";
        RusStrings[58] = "Врагов уничтожено:";
        RusStrings[59] = "Лучшее время:";
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
        EngStrings[11] = "YOU WIN!\n Your time:";
        EngStrings[12] = "Your best time:";
        EngStrings[13] = "Try again?";
        EngStrings[14] = "Return to Windows";
        EngStrings[15] = "Secrets found:";
        EngStrings[16] = "Score:";
        EngStrings[17] = "Best score:";
        EngStrings[18] = "Return to Main Menu";
        EngStrings[19] = "Exit is opened!";
        EngStrings[20] = "Secret ash leader is here!";
        EngStrings[21] = "All kids are saved! \n +2 damage and +0.2 speed!";
        EngStrings[22] = "Kids saved:";
        EngStrings[23] = "Enemies defeated:";
        EngStrings[24] = "APOCALYPSE HAS STARTED";
        EngStrings[25] = "ASH PEOPLE KILLED YOU";
        EngStrings[26] = "Go to next level";
        EngStrings[27] = "YOU WIN!";
        EngStrings[28] = "On this level";
        EngStrings[29] = "Your time:";
        EngStrings[30] = "Your best time:";
        EngStrings[31] = "Score:";
        EngStrings[32] = "Best score:";
        EngStrings[33] = "Story mode";
        EngStrings[34] = "Best score:";
        EngStrings[35] = "Try again?";
        EngStrings[36] = "Return to Windows";
        EngStrings[37] = "Return to Main Menu";
        EngStrings[38] = "Secrets found:";
        EngStrings[39] = "Kids saved:";
        EngStrings[40] = "Enemies defeated:";
        EngStrings[41] = "YOU WIN!";
        EngStrings[42] = "On this level";
        EngStrings[43] = "Your time:";
        EngStrings[44] = "Your best time:";
        EngStrings[45] = "Score:";
        EngStrings[46] = "Best score:";
        EngStrings[47] = "Story mode";
        EngStrings[48] = "Your time:";
        EngStrings[49] = "Your best time:";
        EngStrings[50] = "Score:";
        EngStrings[51] = "Best score:";
        EngStrings[52] = "Try again?";
        EngStrings[53] = "Go to next level";
        EngStrings[54] = "Return to Windows";
        EngStrings[55] = "Return to Main Menu";
        EngStrings[56] = "Secrets found:";
        EngStrings[57] = "Kids saved:";
        EngStrings[58] = "Enemies defeated:";
        EngStrings[59] = "Your best time:";
    }

    public void translateToRussian()
    {
        for (int i = 0; i <= 59; i++)
        {
            Texts[i].text = RusStrings[i];
            Texts[i].font = rusFont;
        }
    }

    public void translateToEnglish()
    {
        for (int i = 0; i <= 59; i++)
        {
            Texts[i].text = EngStrings[i];
            Texts[i].font = engFont;
        }
    }
}
