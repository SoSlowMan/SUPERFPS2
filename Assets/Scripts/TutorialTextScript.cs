using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string current = transform.gameObject.name;
            switch (current)
            {
                case "tutorStart":
                    PlayerController.instance.tutorialStartScreen.SetActive(true);
                    break;
                case "tutorUI":
                    PlayerController.instance.tutorialUIScreen.SetActive(true);
                    break;
                case "tutorApple":
                    PlayerController.instance.tutorialFruitScreen.SetActive(true);
                    break;
                case "tutorSecret":
                    PlayerController.instance.tutorialSecretScreen.SetActive(true);
                    break;
                case "tutorEnemy":
                    PlayerController.instance.tutorialEnemyScreen.SetActive(true);
                    break;
                case "tutorKid":
                    PlayerController.instance.tutorialKidScreen.SetActive(true);
                    break;
                case "tutorBoss":
                    PlayerController.instance.tutorialBossScreen.SetActive(true);
                    break;

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            string current = transform.gameObject.name;
            switch (current)
            {
                case "tutorStart":
                    PlayerController.instance.tutorialStartScreen.SetActive(false);
                    break;
                case "tutorUI":
                    PlayerController.instance.tutorialUIScreen.SetActive(false);
                    break;
                case "tutorApple":
                    PlayerController.instance.tutorialFruitScreen.SetActive(false);
                    break;
                case "tutorSecret":
                    PlayerController.instance.tutorialSecretScreen.SetActive(false);
                    break;
                case "tutorEnemy":
                    PlayerController.instance.tutorialEnemyScreen.SetActive(false);
                    break;
                case "tutorKid":
                    PlayerController.instance.tutorialKidScreen.SetActive(false);
                    break;
                case "tutorBoss":
                    PlayerController.instance.tutorialBossScreen.SetActive(false);
                    break;
            }

        }

    }
}