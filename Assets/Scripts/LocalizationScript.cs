using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationScript : MonoBehaviour
{
    //public Text bestTime, bestScore, buttonStart, buttonTutor, buttonStory, buttonCredits, buttonOptions, buttonExit;
    //public Text optionsLabel, optionGraphics, optionFullscreen, optionVSync, optionResolution, optionApply, optionLanguage, optionApplyLanguage, optionAudio, optionMaster, optionMusic, optionSFX, optionDelete, optionClose;
    public string language;
    public static LocalizationScript instance;
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

    void createEngList()
    {
        EngStrings[0] = "Best time: ";
        EngStrings[1] = "Best score: ";
        EngStrings[2] = " Start the game ";
        EngStrings[3] = " Tutorial ";
        EngStrings[4] = " Story ";
        EngStrings[5] = " Credits ";
        EngStrings[6] = " Options ";
        EngStrings[7] = " Exit to Windows ";
        EngStrings[8] = "OPTIONS";
        EngStrings[9] = "GRAPHICS";
        EngStrings[10] = "Fullscreen";
        EngStrings[11] = "VSync";
        EngStrings[12] = "Resolution";
        EngStrings[13] = "Apply";
        EngStrings[14] = "Language";
        EngStrings[15] = "Apply";
        EngStrings[16] = "AUDIO";
        EngStrings[17] = "Master Volume";
        EngStrings[18] = "Music Volume";
        EngStrings[19] = "SFX Volume";
        EngStrings[20] = "Delete saves";
        EngStrings[21] = "Close options";
        EngStrings[22] = "THE STORY";
        EngStrings[23] = "The cult of crazy ash people from Volcano island have only one goal in life: to start the apocalypse! To complete doomsday ritual they need to have big magic emerald and 10 innocent souls.  So, on one faithful night, they stole the emerald and 10 kids from nearby Fruit island and are ready to do the ultimate sacrifice: destroy everything in the heat of volcano. \n The Fruit island is in a big sorrow.Their only hope is you - the best warrior on the island!Ash people are dangerous and the time is running out, so you need to be careful and fast. Saved kids will help you along the way, the emerald will transfer them back home and give you boosts. Good luck!";
        EngStrings[24] = "Close";
        EngStrings[25] = "CREDITS";
        EngStrings[26] = "Close";
        EngStrings[27] = "LOADING";
        EngStrings[28] = "Press any button to continue";
    }

    void createRusList()
    {
        RusStrings[0] = "Лучшее время: ";
        RusStrings[1] = "Лучший счет: ";
        RusStrings[2] = " Начать игру ";
        RusStrings[3] = " Обучение ";
        RusStrings[4] = " История ";
        RusStrings[5] = " Титры ";
        RusStrings[6] = " Опции ";
        RusStrings[7] = " Выйти из игры ";
        RusStrings[8] = "ОПЦИИ";
        RusStrings[9] = "ГРАФИКА";
        RusStrings[10] = "Полный экран";
        RusStrings[11] = "Разрешение";
        RusStrings[12] = "Верт. Синхронизация";
        RusStrings[13] = " Применить ";
        RusStrings[14] = "Язык";
        RusStrings[15] = " Применить ";
        RusStrings[16] = "АУДИО";
        RusStrings[17] = "Общая громкость";
        RusStrings[18] = "Громкость музыки";
        RusStrings[19] = "Громкость звуков";
        RusStrings[20] = " Удалить сохранения ";
        RusStrings[21] = " Закрыть опции ";
        RusStrings[22] = "ИСТОРИЯ";
        RusStrings[23] = "Безумные культисты, живущие на острове Вулкана, называют себя народом пепла и имеют всего одну цель в жизни: устроить апокалипсис! Чтобы совершить ритуал конца света им нужен большой магический изумруд и 10 невинных душ. В одну роковую ночь они выкрали изумруд и 10 детей с острова Фруктов неподалеку, и теперь они готовы совершить великое жертвоприношение: скинуть все это в жерло вулкана. \n Остров Фруктов в трауре. Их единственная надежда - ты, лучший воин на острове. Народ пепла очень опасен, время на исходе, так что тебе нужно быть осторожным и быстрым. Спасенные дети помогут тебе по пути, изумруд отправит их домой и даст тебе бонусы. Удачи!";
        RusStrings[24] = "Закрыть";
        RusStrings[25] = "Титры";
        RusStrings[26] = "Закрыть";
        RusStrings[27] = "ЗАГРУЗКА";
        RusStrings[28] = "Нажмите любую клавишу чтобы продолжить";
    }

   public void translateToRussian()
    {
        for (int i = 0; i <= 28; i++)
        {
            Texts[i].text = RusStrings[i];
            Texts[i].font = rusFont;
        }
    }

    public void translateToEnglish()
    {
        for (int i = 0; i <= 28; i++)
        {
            Texts[i].text = EngStrings[i];
            Texts[i].font = engFont;
        }
    }

    /* public void translateToRussian()
     {
         //main menu screen
         bestTime.text = "Лучшее время: ";
         bestTime.font = rusFont;
         bestScore.text = "Лучший счет: ";
         bestScore.font = rusFont;
         buttonStart.text = " Начать игру ";
         buttonStart.font = rusFont;
         buttonTutor.text = " Обучение ";
         buttonTutor.font = rusFont;
         buttonStory.text = " История ";
         buttonStory.font = rusFont;
         buttonCredits.text = " Титры ";
         buttonCredits.font = rusFont;
         buttonOptions.text = " Опции ";
         buttonOptions.font = rusFont;
         buttonExit.text = " Выйти из игры ";
         buttonExit.font = rusFont;
         //options screen
         optionsLabel.text = "ОПЦИИ";
         optionsLabel.font = rusFont;
         optionGraphics.text = "ГРАФИКА";
         optionGraphics.font = rusFont;
         optionFullscreen.text = "Полный экран";
         optionFullscreen.font = rusFont;
         optionResolution.text = "Разрешение";
         optionResolution.font = rusFont;
         optionVSync.text = "Верт. Синхронизация";
         optionVSync.font = rusFont;
         optionApply.text = " Применить ";
         optionApply.font = rusFont;
         optionLanguage.text = "Язык";
         optionLanguage.font = rusFont;
         optionApplyLanguage.text = " Применить ";
         optionApplyLanguage.font = rusFont;
         optionAudio.text = "АУДИО";
         optionAudio.font = rusFont;
         optionMaster.text = "Общая громкость";
         optionMaster.font = rusFont;
         optionMusic.text = "Громкость музыки";
         optionMusic.font = rusFont;
         optionSFX.text = "Громкость звуков";
         optionSFX.font = rusFont;
         optionDelete.text = " Удалить сохранения ";
         optionDelete.font = rusFont;
         optionClose.text = " Закрыть опции ";
         optionClose.font = rusFont;

     }
     public void translateToEnglish()
     {
         //main menu screen
         bestTime.text = "Best time: ";
         bestTime.font = engFont;
         bestScore.text = "Best score: ";
         bestScore.font = engFont;
         buttonStart.text = " Start the game ";
         buttonStart.font = engFont;
         buttonTutor.text = " Tutorial ";
         buttonTutor.font = engFont;
         buttonStory.text = " Story ";
         buttonStory.font = engFont;
         buttonCredits.text = " Credits ";
         buttonCredits.font = engFont;
         buttonOptions.text = " Options ";
         buttonOptions.font = engFont;
         buttonExit.text = " Exit to Windows ";
         buttonExit.font = engFont;
         //options screen
         optionsLabel.text = "OPTIONS";
         optionsLabel.font = engFont;
         optionGraphics.text = "GRAPHICS";
         optionGraphics.font = engFont;
         optionFullscreen.text = "Fullscreen";
         optionFullscreen.font = engFont;
         optionVSync.text = "VSync";
         optionVSync.font = engFont;
         optionResolution.text = "Resolution";
         optionResolution.font = engFont;
         optionApply.text = "Apply";
         optionApply.font = engFont;
         optionLanguage.text = "Language";
         optionLanguage.font = engFont;
         optionApplyLanguage.text = "Apply";
         optionApplyLanguage.font = engFont;
         optionAudio.text = "AUDIO";
         optionAudio.font = engFont;
         optionMaster.text = "Master Volume";
         optionMaster.font = engFont;
         optionMusic.text = "Music Volume";
         optionMusic.font = engFont;
         optionSFX.text = "SFX Volume";
         optionSFX.font = engFont;
         optionDelete.text = "Delete saves";
         optionDelete.font = engFont;
         optionClose.text = "Close options";
         optionClose.font = engFont;

     }*/

}

