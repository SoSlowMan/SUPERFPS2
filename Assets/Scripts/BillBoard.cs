using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        //потому что ебаный скрипт переворачивает текстуры ставим вот это
        theSR.flipX = true;
        theSR.flipY = false;
    }

    // Update is called once per frame
    void Update()
    {
        //поскольку у нас 1 игрок, мы можем с помощью такой ебалы все время получать его позицию чтобы разворачивать к нему спрайты 
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
    }
}
