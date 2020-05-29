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
            AudioController.instance.backgroundMusic.Stop();
            AudioController.instance.winSound.Play();
        }
    }
}
