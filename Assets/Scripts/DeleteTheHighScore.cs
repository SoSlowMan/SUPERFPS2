using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTheHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteTheHighScore()
    {
        PlayerPrefs.DeleteKey("BestScore");
        PlayerPrefs.DeleteKey("ScoreTime");
        PlayerPrefs.DeleteKey("BestTime");
        PlayerPrefs.DeleteKey("BestScore2");
        PlayerPrefs.DeleteKey("ScoreTime2");
        PlayerPrefs.DeleteKey("BestTime2");
        //BestScoreScript.instance.successDeletionText.SetActive(true); 
    }
}
