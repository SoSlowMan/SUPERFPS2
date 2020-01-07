using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject tutorial;

    public float playerRange;

    public Rigidbody2D theRB;
    //public float moveSpeed;

    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
        coin = Random.Range(0, 2);
        theRB.velocity = Vector2.zero;
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
                if (coin == 0)
                {
                    PlayerController.instance.moveSpeedMultiplier = PlayerController.instance.moveSpeedMultiplier + 0.1f;
                    PlayerController.instance.AddMoveSpeed();
                }
                else
                {
                    PlayerController.instance.AddDamage();
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
}
