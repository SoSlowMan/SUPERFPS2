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
    public Text forward, backward, left, right, restart, exit;
    //public GameObject forwardChange, backwardChange, leftChange, rightChange, restartChange, ExitChange;

    public GameObject currentKey;

    private Color32 normal = new Color32(249, 202, 74, 255);
    private Color32 selected = new Color32(209, 170, 60, 255);

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MouseSens"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSens");
            sensSlider.value = PlayerPrefs.GetFloat("MouseSens");
        }
        sensLabel.text = (mouseSensitivity).ToString();

        /*if (PlayerPrefs.HasKey("keyForward"))
        {
            forward.text = PlayerPrefs.GetString("keyForward");
            backward.text = PlayerPrefs.GetString("keyBackward");
            left.text = PlayerPrefs.GetString("keyLeft");
            right.text = PlayerPrefs.GetString("keyRight");
            restart.text = PlayerPrefs.GetString("keyRestart");
            exit.text = PlayerPrefs.GetString("keyExit");
        }
        else FirstTime();*/
        keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
        keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Restart", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Restart", "F")));
        keys.Add("Exit", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Exit", "Escape")));
        forward.text = PlayerPrefs.GetString("Forward");
        backward.text = PlayerPrefs.GetString("Backward");
        left.text = PlayerPrefs.GetString("Left");
        right.text = PlayerPrefs.GetString("Right");
        restart.text = PlayerPrefs.GetString("Restart");
        exit.text = PlayerPrefs.GetString("Exit");

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

    private void FirstTime()
    {
        keys.Add("Forward", KeyCode.W);
        //PlayerPrefs.SetString("keyForward",KeyCode.W.ToString());
        keys.Add("Backward", KeyCode.S);
        //PlayerPrefs.SetString("keyBackward", KeyCode.S.ToString());
        keys.Add("Left", KeyCode.A);
        //PlayerPrefs.SetString("keyLeft", KeyCode.A.ToString());
        keys.Add("Right", KeyCode.D);
        //PlayerPrefs.SetString("keyRight", KeyCode.D.ToString());
        keys.Add("Restart", KeyCode.F);
        //PlayerPrefs.SetString("keyRestart", KeyCode.F.ToString());
        keys.Add("Exit", KeyCode.Escape);
        //PlayerPrefs.SetString("keyExit", KeyCode.Escape.ToString());
    }

    /*public void ChangeForward()
    {
        forwardChange.SetActive(true);
        //forward = Input.GetKeyDown();
        OnGUI();
        //newKey = Input..ToString();
        PlayerPrefs.SetString("keyForward",newKey);
        forward.text = PlayerPrefs.GetString("keyForward");
        //newKey = null;
        forwardChange.SetActive(false);
    }*/

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
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
}
