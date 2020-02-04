using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");//грузит сцену в фоне, чтобы мог показаться товарищ лоудинг скрин

        asyncLoad.allowSceneActivation = false;
        
        while(!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= .9f)
            {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);
                if(Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    loadingScreen.SetActive(false);
                }
            }
            yield return null;
        }
    }
}
