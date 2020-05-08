using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject meteor;
    public Vector3 meteorPos;
    public Quaternion meteorRot;
    public Rigidbody myRigidbody;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //meteorPos = new Vector3(meteor.transform.position.x, meteor.transform.position.y, meteor.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x - 0.002f, myRigidbody.velocity.y, myRigidbody.velocity.z + 0.001f);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 0.01f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 0.01f);
    }
}
