using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public static EnemyController instance;

    //public GameObject Enemy;

    public int health = 3;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = .5f; //темп стрельбы
    private float shotCounter; //счетчик выстрелов
    public GameObject bullet; 
    public Transform firePoint; //где спавнить пулю

    /*private void Awake()
    {
        instance = this;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange && PlayerController.instance.hasDied == false)
        {
            transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
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

    public void TakeDamage()
    {
        //health--;
        health -= PlayerController.instance.damage;
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
