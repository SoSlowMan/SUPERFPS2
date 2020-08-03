﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.winScreen.SetActive(true);
            PlayerController.instance.hasDied = true;
            PlayerController.instance.winCubeScreen.SetActive(false);
            PlayerController.instance.deadScreen.SetActive(false);
            PlayerController.instance.secretBossScreen.SetActive(false);
            PlayerController.instance.kidRewardScreen.SetActive(false);
            AudioController.instance.backgroundMusic.Stop();
            AudioController.instance.winSound.Play();
            if (PlayerPrefs.HasKey("StoryMode"))
            {
                PlayerController.instance.nextLevelButton.SetActive(true);
            }
        }
    }
}
