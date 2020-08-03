using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject OptionsScreen;
    public GameObject CreditsScreen;
    public GameObject StoryScreen;
    public GameObject KeyboardScreen, ScoresScreen, LevelScreen;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.PlayMainMenuMusic();
        PlayerPrefs.DeleteKey("StoryMode");
        PlayerPrefs.DeleteKey("jungleKills100");
        PlayerPrefs.DeleteKey("jungleKids100");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openOptions()
    {
        MainMenuScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }

    public void closeOptions()
    {
        MainMenuScreen.SetActive(true);
        OptionsScreen.SetActive(false);
    }

    public void openCredits()
    {
        MainMenuScreen.SetActive(false);
        CreditsScreen.SetActive(true);
    }

    public void closeCredits()
    {
        MainMenuScreen.SetActive(true);
        CreditsScreen.SetActive(false);
    }

    public void openStory()
    {
        MainMenuScreen.SetActive(false);
        StoryScreen.SetActive(true);
    }

    public void closeStory()
    {
        MainMenuScreen.SetActive(true);
        StoryScreen.SetActive(false);
    }

    public void openKeyboard()
    {
        OptionsScreen.SetActive(false);
        KeyboardScreen.SetActive(true);
    }

    public void closeKeyboard()
    {
        OptionsScreen.SetActive(true);
        KeyboardScreen.SetActive(false);
    }

    public void openScores()
    {
        MainMenuScreen.SetActive(false);
        ScoresScreen.SetActive(true);
    }

    public void closeScores()
    {
        MainMenuScreen.SetActive(true);
        ScoresScreen.SetActive(false);
    }

    public void openLevels()
    {
        MainMenuScreen.SetActive(false);
        LevelScreen.SetActive(true);
    }

    public void closeLevels()
    {
        MainMenuScreen.SetActive(true);
        LevelScreen.SetActive(false);
    }
}
