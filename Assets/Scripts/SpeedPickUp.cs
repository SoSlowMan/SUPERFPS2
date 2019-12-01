using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float timeRemaining = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if (PlayerController.instance.speedFlag == true && PlayerController.instance.speedTime > 0) {
            PlayerController.instance.speedTime -= Time.deltaTime;
        }
        else {
            PlayerController.instance.ReduceSpeed(speedMultiplier);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //шобы знать что конкретно игрок впилился головой в коллайдер
        if (other.tag == "Player")
        {
            if (PlayerController.instance.moveSpeed == PlayerController.instance.currentSpeed)
            {
                PlayerController.instance.AddSpeed(speedMultiplier);

                AudioController.instance.PlayHealthPickup();

                Destroy(gameObject);
            }

        }
    }
}

