using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagementScript : MonoBehaviour
{
    public GameObject loadingScreen, loadingText, mainmenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        StartCoroutine(LoadJungle());
        //SceneManager.LoadScene("jungle");
    }

    public void ResetStory()
    {
        PlayerPrefs.DeleteKey("jungleKills100");
        PlayerPrefs.DeleteKey("jungleKids100");
        PlayerPrefs.DeleteKey("TimeStory1");
        PlayerPrefs.DeleteKey("TimeStory2");
        PlayerPrefs.DeleteKey("ScoreTimeStory1");
        PlayerPrefs.DeleteKey("ScoreTimeStory2");
        PlayerPrefs.DeleteKey("ScoreStory1");
        PlayerPrefs.DeleteKey("ScoreStory2");
        SceneManager.LoadScene("jungle");
    }

    public void StartLevel2()
    {
        StartCoroutine(LoadDreamcast());
    }

    public void StartTheStory()
    {
        PlayerPrefs.SetInt("StoryMode", 1);
        StartCoroutine(LoadJungle());
    }

    public void StartTutorial()
    {
        StartCoroutine(LoadTutor());
        //SceneManager.LoadScene("tutor");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        //StartCoroutine(LoadMain());
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);
        mainmenu.SetActive(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");//грузит сцену в фоне, чтобы мог показаться товарищ лоудинг скрин

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.SetActive(true);
                //loadingIcon.SetActive(false);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    loadingScreen.SetActive(false);
                }
            }
            yield return null;
        }
    }

    public IEnumerator LoadJungle()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("jungle");//грузит сцену в фоне, чтобы мог показаться товарищ лоудинг скрин

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.SetActive(true);
                //loadingIcon.SetActive(false);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    loadingScreen.SetActive(false);
                }
            }
            yield return null;
        }
    }

    public IEnumerator LoadTutor()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("tutor");//грузит сцену в фоне, чтобы мог показаться товарищ лоудинг скрин

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.SetActive(true);
                //loadingIcon.SetActive(false);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    loadingScreen.SetActive(false);
                }
            }
            yield return null;
        }
    }

    public IEnumerator LoadDreamcast()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("dreamcast");

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.SetActive(true);
                //loadingIcon.SetActive(false);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    loadingScreen.SetActive(false);
                }
            }
            yield return null;
        }
    }
}
