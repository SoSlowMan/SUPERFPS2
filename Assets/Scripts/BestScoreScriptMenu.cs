using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScriptMenu : MonoBehaviour
{

    public static BestScoreScriptMenu instance;

    public int bestScore;
    public Text counterText;

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            updateScoreText();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            updateScoreText();
        }
        else
        {

        }
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateScoreText()
    {
        counterText.text = bestScore.ToString("0");
    }
}
