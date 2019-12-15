using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreScript : MonoBehaviour
{

    public static BestScoreScript instance;

    int score;
    public int bestScore = 0;
    public Text counterText;
    public GameObject successDeletionText;

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
        score = PlayerController.instance.score;
        if (bestScore == 0)
        {
            bestScore = score; //для первого запуска
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        successDeletionText.SetActive(false); //текст дающий понять что хайскор был удален, ставлю в фолс чтобы не светился если я текст не удалил
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= bestScore)
        {
            bestScore = score;

            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        updateScoreText();
    }

    /*void newbestScore()
    {
        bestScore = time;
    }*/

    void updateScoreText()
    {
        counterText.text = bestScore.ToString("0");
    }
}
