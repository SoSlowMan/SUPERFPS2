using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FriendController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject tutorial;

    public float playerRange;

    public Rigidbody2D theRB;
    //public float moveSpeed;

    public int coin;

    public string language;
    //public static LocalizeTutorScript instance;
    public Font rusFont, engFont;
    public Text[] Texts;
    public string[] RusStrings;
    public string[] EngStrings;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
        coin = Random.Range(0, 2);
        theRB.velocity = Vector2.zero;
        createEngList();
        createRusList();
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetString("Language");
            if (PlayerPrefs.GetString("Language") == "Русский")
            {
                translateToRussian();
            }
            else
            {
                translateToEnglish();
            }
        }
        else
        {
            PlayerPrefs.SetString("Language", "English");
            translateToEnglish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = Vector2.zero;
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange) //добавить UI чтоб игрок понимал ч куда
        {
            tutorial.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                if (SceneManager.GetActiveScene().name == "jungle" && PlayerController.instance.kidCounter == 9)
                {
                    if (coin == 0)
                    {
                        PlayerController.instance.moveSpeedMultiplier = PlayerController.instance.moveSpeedMultiplier + 0.1f;
                        PlayerController.instance.AddMoveSpeed();
                    }
                    else
                    {
                        PlayerController.instance.AddDamage();
                    }
                    PlayerController.instance.moveSpeedMultiplier = PlayerController.instance.moveSpeedMultiplier + 0.3f;
                    PlayerController.instance.AddMoveSpeed();
                    PlayerController.instance.Add3Damage();
                }
                else
                {
                    if (coin == 0)
                    {
                        PlayerController.instance.moveSpeedMultiplier = PlayerController.instance.moveSpeedMultiplier + 0.1f;
                        PlayerController.instance.AddMoveSpeed();
                    }
                    else
                    {
                        PlayerController.instance.AddDamage();
                    }
                }                  
                Destroy(gameObject);
                PlayerController.instance.kidCounter++;
                Instantiate(explosion, transform.position + new Vector3(0, 0, .65f), transform.rotation);
                AudioController.instance.PlayHealthPickup();
                AudioController.instance.PlayEnemyDeath();
            }
        }
        else
        {
            tutorial.SetActive(false);
        }


                 
     }

    void createRusList()
    {
        RusStrings[0] = "Нажми \"E\" чтобы спасти меня:";
    }

    void createEngList()
    {
        EngStrings[0] = "Press \"E\" to save me:";
    }

    void translateToRussian()
    {
            Texts[0].text = RusStrings[0];
            Texts[0].font = rusFont;
    }

    void translateToEnglish()
    {
        Texts[0].text = EngStrings[0];
        Texts[0].font = engFont;
    }

}
