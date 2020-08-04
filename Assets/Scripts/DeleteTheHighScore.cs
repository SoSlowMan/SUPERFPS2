using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTheHighScore : MonoBehaviour
{
    public GameObject messageText;

    public void deleteTheHighScore()
    {
        messageText.SetActive(true);
        PlayerPrefs.DeleteKey("BestScore");
        PlayerPrefs.DeleteKey("ScoreTime");
        PlayerPrefs.DeleteKey("BestTime");
        PlayerPrefs.DeleteKey("BestScore2");
        PlayerPrefs.DeleteKey("ScoreTime2");
        PlayerPrefs.DeleteKey("BestTime2");
    }
}
