﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsScreen;
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
}
