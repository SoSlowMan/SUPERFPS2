using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 25;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //шобы знать что конкретно игрок впилился головой в коллайдер
        if (other.tag == "Player")
        {
            if (PlayerController.instance.currentHealth == PlayerController.instance.maxHealth)
            {

            }
            else
            {
                PlayerController.instance.AddHealth(healthAmount);
                PlayerController.instance.UpdateAmmoUI();

                AudioController.instance.PlayHealthPickup();

                Destroy(gameObject);
            }
                         
        }
    }
}

