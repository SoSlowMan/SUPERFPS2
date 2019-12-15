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
        //BestScoreScript.instance.successDeletionText.SetActive(true); 
    }
}
