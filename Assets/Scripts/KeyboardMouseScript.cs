using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardMouseScript : MonoBehaviour
{
    public Slider sensSlider;
    public Text sensLabel;
    public float mouseSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MouseSens"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSens");
            sensSlider.value = PlayerPrefs.GetFloat("MouseSens");
        }
        sensLabel.text = (mouseSensitivity).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSensitivity()
    {
        mouseSensitivity = sensSlider.value;
        sensLabel.text = (mouseSensitivity/100).ToString();
        PlayerPrefs.SetFloat("MouseSens", sensSlider.value);
    }
}
