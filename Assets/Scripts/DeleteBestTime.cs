using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBestTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteBestTime()
    {
        PlayerPrefs.DeleteKey("BestTime"); //удаляю из памяти компа лучшее время
        PlayerPrefs.DeleteKey("BestTimeStory1");
        PlayerPrefs.DeleteKey("BestTimeStory2");
        PlayerPrefs.DeleteKey("BestTime2");
        PlayerPrefs.DeleteKey("BestTimeStory");
        PlayerPrefs.DeleteKey("TimeStory1");
        PlayerPrefs.DeleteKey("TimeStory2");
    }
}
