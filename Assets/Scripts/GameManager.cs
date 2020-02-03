using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            UnlockCursor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.hasDied == true || Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }
        else if(Input.GetMouseButton(0))
        {
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
