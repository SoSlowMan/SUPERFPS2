using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public static FriendController instance;

    public int health = 3;
    public GameObject explosion;

    public float playerRange = 1f;
    public float enemyRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = .4f; //темп стрельбы
    private float shotCounter; //счетчик выстрелов
    public GameObject bullet; 
    public Transform firePoint; //где спавнить пулю
    bool isFriend;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isFriend = false;
        shouldShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange && Input.GetKeyDown("e"))
            {
                isFriend = true;
                shouldShoot = true;
                if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > playerRange)
                {
                    transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
                    Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;
                    theRB.velocity = playerDirection.normalized * moveSpeed;

                if (shouldShoot && Vector3.Distance(transform.position, EnemyController.instance.transform.position) < enemyRange)
                {
                    shotCounter -= Time.deltaTime;
                    if (shotCounter <= 0)//типа если враг не стрелял то он начинает 
                    {
                        transform.LookAt(EnemyController.instance.transform.position, -Vector3.forward);
                        Instantiate(bullet, firePoint.position, firePoint.rotation);
                        shotCounter = fireRate;
                    }
                }
            }
            else
            {
                theRB.velocity = Vector2.zero;
            }
        }
        
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position + new Vector3(0,0,.65f), transform.rotation);
            AudioController.instance.PlayEnemyDeath();
        }
        else
        {
            AudioController.instance.PlayEnemyShot();
        }
    }
}
