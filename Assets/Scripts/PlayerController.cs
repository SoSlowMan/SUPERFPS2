using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PLAYER MOVEMENT
        //как я понял привязка ходьбы к осям
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //нужно чтобы можно было поворачиваться и тупой юнити не ходил по тем же блять координатам даже если ебало повернуто куда-то
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
        //собсна движение
        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        //PLAYER VIEW CONTROL
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        //LEFTRIGHT
        //Quaterion тк в юнити ротейшон состоит из 4 значений, а не 2, поэтому Вектор2/3 не покатит
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
        //UPDOWN
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

        //shooting
        if(Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("I'm looking at " + hit.transform.name);
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                }
                else
                {
                    Debug.Log("What the fuck? What am I looking at?");
                }
                currentAmmo--;
            }
        }
    }
}
