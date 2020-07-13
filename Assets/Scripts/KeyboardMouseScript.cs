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
    public GameObject forwardChange, backwardChange, leftChange, rightChange, restartChange, ExitChange;
    public string newKey;

    public GameObject currentKey;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MouseSens"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSens");
            sensSlider.value = PlayerPrefs.GetFloat("MouseSens");
        }
        sensLabel.text = (mouseSensitivity).ToString();

        if (PlayerPrefs.HasKey("keyForward"))
        {
            forward.text = PlayerPrefs.GetString("keyForward");
            backward.text = PlayerPrefs.GetString("keyBackward");
            left.text = PlayerPrefs.GetString("keyLeft");
            right.text = PlayerPrefs.GetString("keyRight");
            restart.text = PlayerPrefs.GetString("keyRestart");
            exit.text = PlayerPrefs.GetString("keyExit");
        }
        else FirstTime();
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
        PlayerPrefs.SetString("keyForward",KeyCode.W.ToString());
        keys.Add("Backward", KeyCode.S);
        PlayerPrefs.SetString("keyBackward", KeyCode.S.ToString());
        keys.Add("Left", KeyCode.A);
        PlayerPrefs.SetString("keyLeft", KeyCode.A.ToString());
        keys.Add("Right", KeyCode.D);
        PlayerPrefs.SetString("keyRight", KeyCode.D.ToString());
        keys.Add("Restart", KeyCode.F);
        PlayerPrefs.SetString("keyRestart", KeyCode.F.ToString());
        keys.Add("Exit", KeyCode.Escape);
        PlayerPrefs.SetString("keyExit", KeyCode.Escape.ToString());
    }

    public void ChangeForward()
    {
        forwardChange.SetActive(true);
        //forward = Input.GetKeyDown();
        OnGUI();
        //newKey = Input..ToString();
        PlayerPrefs.SetString("keyForward",newKey);
        forward.text = PlayerPrefs.GetString("keyForward");
        //newKey = null;
        forwardChange.SetActive(false);
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
