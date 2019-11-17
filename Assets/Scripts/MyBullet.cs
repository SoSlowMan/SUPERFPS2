using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed = 5f;

    //public Rigidbody theRB;

    //private Vector3 direction;

    //private Quaternion rot;

    //public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //rot = PlayerController.instance.transform.rotation;
        //rot = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, Player.transform.rotation.eulerAngles.y, Player.transform.rotation.eulerAngles.z);
        //direction = PlayerController.instance.transform.position + rot.eulerAngles;
        //direction.Normalize();
        //direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        //transform.Translate(Vector3. * bulletSpeed * Time.deltaTime);
        //theRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            transform.parent.GetComponent<EnemyController>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
