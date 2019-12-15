using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTrigger : MonoBehaviour
{
    float aliveTime = 3f;
    public float checkTime;
    public bool enterFlag;
    // Start is called before the first frame update
    void Start()
    {
        enterFlag = false;
    }

    void Update()
    {
        if (enterFlag == true)
        {
            checkTime += Time.deltaTime;
            if (aliveTime < checkTime)
            {
                PlayerController.instance.secretScreen.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterFlag = true;
            PlayerController.instance.secretScreen.SetActive(true);
            PlayerController.instance.secretCounter = PlayerController.instance.secretCounter + 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.secretScreen.SetActive(false);
            Destroy(gameObject);
        }
    }
}
