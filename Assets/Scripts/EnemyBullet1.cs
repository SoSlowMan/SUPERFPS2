using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    //public int damageAmount;

    public float bulletSpeed = 5f;

    public Rigidbody2D theRB;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //direction = PlayerController.instance.transform.position + transform.position;
        //.Normalize();
        //direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //theRB.velocity = direction * bulletSpeed;
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            EnemyController.instance.TakeDamage();

            Destroy(gameObject);
        }
    }
}
