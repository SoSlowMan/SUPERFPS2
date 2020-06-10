using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeTutorScript : MonoBehaviour
{
    public string language;
    public static LocalizeTutorScript instance;
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
        RusStrings[5] = "Ты нашел секрет!";
        RusStrings[6] = "Привет и добро пожаловать в JungleFever. Этот обучаюший уровень объяснит механики игры. Просто идите вперед и повеселитесь!";
        RusStrings[7] = "Ваша задача в игре: найти самый быстрый путь к выходу и набрать как можно больше очков. Нажмите R чтобы перезапустить уровень и M чтобы выйти в главное меню.";
        RusStrings[8] = "По пути вы найдете фрукты. Бананы дадут здоровье. Яблоки в 2 раза увеличат скорость на несколько секунд. А вишня добавит патронов.";
        RusStrings[9] = "Не беспокойтесь, перед вами не просто стена, это СЕКРЕТНАЯ СТЕНА. Через нее можно пройти!";
        RusStrings[10] = "Это шутер, так что придется стрелять по злым ребятам, вроде этого перед вами.";
        RusStrings[11] = "По пути вы встретите похищенных детей, если их спасти, нажав \"E\", они дадут вам +0.1 к множителю скорости или +1 к урону (случайно).";
        RusStrings[12] = "Это босс, большой и страшный, сейчас он атаковать не будет, но определенно будет в игре. Убейте его и проследуйте к выходу (изумруд).";
        RusStrings[13] = "Поздравляем! Теперь вы готовы спасти мир! \n Время:";
        RusStrings[14] = "Секретов найдено:";
        RusStrings[15] = "Счет:";
        RusStrings[16] = "Нажмите \"M\" чтобы вернуться в главное меню";
    }

    void createEngList()
    {
        EngStrings[0] = "Health:";
        EngStrings[1] = "Ammo:";
        EngStrings[2] = "Damage";
        EngStrings[3] = "Speed";
        EngStrings[4] = "Time:";
        EngStrings[5] = "YOU'VE DISCOVERED A SECRET!";
        EngStrings[6] = "Hello and welcome to JungleFever. This tutorial level will explain mechanics of the game. Just go forward and have fun!";
        EngStrings[7] = "Your task in this game is to find the fastest route to the end and to get huge amount of points. Also, press R to restart level and M to exit to the main menu.";
        EngStrings[8] = "On the way you'll find fruits. Bananas give you health. Apples give you X2 speed multiplier for a few seconds. And the cherry will refill your ammo.";
        EngStrings[9] = "Don't worry, this is not a wall in front of you, that's a SECRET WALL. You can go right through it!";
        EngStrings[10] = "This is a shooter, so you'll need to shoot bad guys, like this one in front of you!";
        EngStrings[11] = "Also you'll find kidnapped kids on the way, they'll give you 0.1 speed multiplier or +1 damage (on random) if you'll save them by pressing \"E\" button.";
        EngStrings[12] = "This is a boss, big and scary, he won't attack now but he sure wil when you'll start the game. Destroy him and proceed to the exit (the emerald).";
        EngStrings[13] = "Congratulaions! Now You're ready to save the world! \n Your time:";
        EngStrings[14] = "Secrets found:";
        EngStrings[15] = "SCORE:";
        EngStrings[16] = "Press \"M\" to get back to the Main Menu";

    }

    public void translateToRussian()
    {
        for (int i = 0; i <= 16; i++)
        {
            Texts[i].text = RusStrings[i];
            Texts[i].font = rusFont;
        }
    }

    public void translateToEnglish()
    {
        for (int i = 0; i <= 16; i++)
        {
            Texts[i].text = EngStrings[i];
            Texts[i].font = engFont;
        }
    }
}
