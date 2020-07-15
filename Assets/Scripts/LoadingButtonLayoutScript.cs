using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingButtonLayoutScript : MonoBehaviour
{
    public Text save, restart, exit;

    // Start is called before the first frame update
    void Start()
    {
        save.text = PlayerPrefs.GetString("SaveKids", "E");
        restart.text = PlayerPrefs.GetString("Restart", "F");
        exit.text = PlayerPrefs.GetString("Exit", "Escape");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
