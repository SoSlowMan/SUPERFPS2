using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsScreen;
    public GameObject CreditsScreen;
    public GameObject StoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.PlayMainMenuMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openOptions()
    {
        OptionsScreen.SetActive(true);
    }

    public void closeOptions()
    {
        OptionsScreen.SetActive(false);
    }

    public void openCredits()
    {
        CreditsScreen.SetActive(true);
    }

    public void closeCredits()
    {
        CreditsScreen.SetActive(false);
    }

    public void openStory()
    {
        StoryScreen.SetActive(true);
    }

    public void closeStory()
    {
        StoryScreen.SetActive(false);
    }
}
