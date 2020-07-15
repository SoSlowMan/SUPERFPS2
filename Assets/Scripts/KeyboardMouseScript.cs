using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardMouseScript : MonoBehaviour
{
    public Slider sensSlider;
    public Text sensLabel;
    public float mouseSensitivity;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text forward, backward, left, right, savekids, restart, exit;
    //public GameObject forwardChange, backwardChange, leftChange, rightChange, restartChange, ExitChange;

    public GameObject currentKey, error;

    private Color32 normal = new Color32(249, 202, 74, 255);
    private Color32 selected = new Color32(209, 170, 60, 255);

    private bool keyIsFree;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MouseSens"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSens");
            sensSlider.value = PlayerPrefs.GetFloat("MouseSens");
        }
        sensLabel.text = (mouseSensitivity).ToString();

        keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
        keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("SaveKids", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SaveKids", "E")));
        keys.Add("Restart", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Restart", "F")));
        keys.Add("Exit", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Exit", "Escape")));

        forward.text = PlayerPrefs.GetString("Forward","W");
        backward.text = PlayerPrefs.GetString("Backward", "S");
        left.text = PlayerPrefs.GetString("Left", "A");
        right.text = PlayerPrefs.GetString("Right", "D");
        savekids.text = PlayerPrefs.GetString("SaveKids", "E");
        restart.text = PlayerPrefs.GetString("Restart", "F");
        exit.text = PlayerPrefs.GetString("Exit", "Escape");

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSensitivity()
    {
        mouseSensitivity = sensSlider.value;
        sensLabel.text = (mouseSensitivity).ToString() + "%";
        PlayerPrefs.SetFloat("MouseSens", sensSlider.value);
    }

    void OnGUI()
    {
        //error.SetActive(false);
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                foreach (var key in keys)
                {
                    if (key.Value == e.keyCode)
                    {
                        error.SetActive(true);
                        currentKey = null;
                        keyIsFree = false;
                        break;
                    }
                    else keyIsFree = true;
                }
                if (keyIsFree == true)
                {
                    keys[currentKey.name] = e.keyCode;
                    currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                    currentKey.GetComponent<Image>().color = normal;
                    error.SetActive(false);
                    currentKey = null;
                }
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public void BackToDefault()
    {
        PlayerPrefs.SetFloat("MouseSens", 100);
        sensSlider.value = 100;
        PlayerPrefs.SetString("Forward", "W");
        PlayerPrefs.SetString("Backward", "S");
        PlayerPrefs.SetString("Left", "A");
        PlayerPrefs.SetString("Right", "D");
        PlayerPrefs.SetString("SaveKids", "E");
        PlayerPrefs.SetString("Restart", "F");
        PlayerPrefs.SetString("Exit", "Escape");

        forward.text = PlayerPrefs.GetString("Forward", "W");
        backward.text = PlayerPrefs.GetString("Backward", "S");
        left.text = PlayerPrefs.GetString("Left", "A");
        right.text = PlayerPrefs.GetString("Right", "D");
        savekids.text = PlayerPrefs.GetString("SaveKids", "E");
        restart.text = PlayerPrefs.GetString("Restart", "F");
        exit.text = PlayerPrefs.GetString("Exit", "Escape");
    }
}
