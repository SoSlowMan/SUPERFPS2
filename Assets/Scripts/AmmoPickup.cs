using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 25;

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
        if(other.tag == "Player")
        {
            //количество патронов хранится в playercontroller, обращаемся к нему и добавляем туда патроны
            PlayerController.instance.currentAmmo += ammoAmount;
            PlayerController.instance.UpdateAmmoUI();

            AudioController.instance.PlayAmmoPickup();

            Destroy(gameObject);
        }
    }
}
