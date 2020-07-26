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
    public Text forward, backward, left, right, savekids, restart, exit, shoot;
    //public GameObject forwardChange, backwardChange, leftChange, rightChange, restartChange, ExitChange;

    public GameObject currentKey, error, press;

    private Color32 normal = new Color32(249, 202, 74, 255);
    private Color32 selected = new Color32(209, 170, 60, 255);

    private bool keyIsFree;

    public float timer;

    public bool newButton;
    public KeyCode fuck;

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
        //еще не добавленные кнопы, чисто для того чтобы ошибка вылезла, если вдруг кто-то захочет на лкм кнопку повесить например
        keys.Add("Shoot", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "Mouse0")));
        keys.Add("Forward2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward2", "UpArrow")));
        keys.Add("Backward2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward2", "DownArrow")));
        keys.Add("Left2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left2", "LeftArrow")));
        keys.Add("Right2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right2", "RightArrow")));
        keys.Add("Unlock", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Unlock", "Q")));//удалить потом

        forward.text = PlayerPrefs.GetString("Forward","W");
        backward.text = PlayerPrefs.GetString("Backward", "S");
        left.text = PlayerPrefs.GetString("Left", "A");
        right.text = PlayerPrefs.GetString("Right", "D");
        savekids.text = PlayerPrefs.GetString("SaveKids", "E");
        restart.text = PlayerPrefs.GetString("Restart", "F");
        exit.text = PlayerPrefs.GetString("Exit", "Escape");
        //shoot.text = PlayerPrefs.GetString("Shoot", "Mouse0");
    }


    // Update is called once per frame
    void Update()
    {
        if (keyIsFree == false)
        {
            if (timer < 3f && newButton == true)
            {
                timer += Time.deltaTime;
            }
            else if (timer >= 3f)
            {
                error.SetActive(false);
                timer = 0f;
                newButton = false;
            }
        }
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
            newButton = true;
            press.SetActive(true);
            if (e.isKey) //|| e.isMouse)
            {
                foreach (var key in keys)
                {
                    if (key.Value == e.keyCode)
                    {
                        fuck = e.keyCode;
                        currentKey.GetComponent<Image>().color = normal;
                        error.SetActive(true);
                        press.SetActive(false);
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
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
                    press.SetActive(false);
                    currentKey = null;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
            Cursor.lockState = CursorLockMode.None;
            error.SetActive(false);
            Cursor.visible = true;
        }
        currentKey = clicked;
        error.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        PlayerPrefs.SetString("Shoot", "Mouse0");

        forward.text = PlayerPrefs.GetString("Forward", "W");
        backward.text = PlayerPrefs.GetString("Backward", "S");
        left.text = PlayerPrefs.GetString("Left", "A");
        right.text = PlayerPrefs.GetString("Right", "D");
        savekids.text = PlayerPrefs.GetString("SaveKids", "E");
        restart.text = PlayerPrefs.GetString("Restart", "F");
        exit.text = PlayerPrefs.GetString("Exit", "Escape");
        //shoot.text = PlayerPrefs.GetString("Shoot", "Mouse0");
    }
}
