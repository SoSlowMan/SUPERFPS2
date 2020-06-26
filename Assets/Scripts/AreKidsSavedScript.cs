﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreKidsSavedScript : MonoBehaviour
{
    public Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = PlayerController.instance.kidCounter.ToString("0") + "/" + PlayerController.instance.amountOfKidsJungle.ToString("0");
    }
}