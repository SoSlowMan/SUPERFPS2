﻿//Time.timeScale = 0f; задел на остановку времени/паузу
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //lesson #3 about billboard
    public static PlayerController instance;

    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;
    public Animator anim; // walk anim

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    public GameObject winScreen;
    public GameObject startScreen;
    public GameObject secretScreen;
    public bool hasDied;

    public Text healthText, ammoText, speedText, damageText;

    public GameObject bullet;
    public Transform firePoint; //где спавнить пулю
    public int damage = 1;

    public float speedTime = 3f;
    public bool speedFlag = false;
    public float defaultMoveSpeed = 5f;
    private float defaultSpeedMultiplier;
    private float defaultSpeedTime = 3f;
    public float moveSpeedMultiplier = 1f;
    public float currentSpeed;

    public int secretCounter;
    public int amountOfSecrets;

    public int killCounter;
    public int kidCounter;

    public int score;

    //tutorial screens
    public GameObject tutorialStartScreen;
    public GameObject tutorialUIScreen;
    public GameObject tutorialFruitScreen;
    public GameObject tutorialSecretScreen;
    public GameObject tutorialEnemyScreen;
    public GameObject tutorialKidScreen;
    public GameObject tutorialBossScreen;

    public int bossCounter;
    public int bossAmount;

    public GameObject winCube;
    public GameObject winCubeScreen;

    public float timer = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        if (SceneManager.GetActiveScene().name == "tutor")
        {
            currentHealth = 75;
        }
        else
        {
            currentHealth = maxHealth;
        }
        //winScreen.SetActive(false);
        deadScreen.SetActive(false);
        healthText.text = currentHealth.ToString() + "%";
        ammoText.text = currentAmmo.ToString();
        speedText.text = moveSpeedMultiplier.ToString() + "X";
        secretCounter = 0;
        if (SceneManager.GetActiveScene().name == "jungle")
        {
            amountOfSecrets = 2;
            bossAmount = 1;
        }
        killCounter = 0;
        kidCounter = 0;
        bossCounter = 0;
        winCube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasDied)
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
            //viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
            firePoint.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            //shooting
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0)
                { 
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                    UpdateAmmoUI();
                    AudioController.instance.PlayGunshot();
                    
                }
            }

            currentSpeed = defaultMoveSpeed * moveSpeedMultiplier;

            if (moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
            //для ускорителей
            if (speedFlag == true)
            {
                speedTime -= Time.deltaTime;
                if (speedTime <= 0)
                {
                    ReduceSpeed();
                }
            }

            score = (killCounter * 200) + (kidCounter * 300) + (30000 - (int)((Time.timeSinceLevelLoad) * 100)) + (secretCounter * 5000) + (bossCounter * 10000);

            if ((secretCounter == amountOfSecrets) || (bossCounter == bossAmount))
            {
                winCube.SetActive(true);
                winCubeScreen.SetActive(true);
                if (timer < 3f)
                {
                    timer += Time.deltaTime;
                }
                else if (timer >= 3f)
                {
                    winCubeScreen.SetActive(false);
                    timer = 3.1f;
                }
            }
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown("m"))
        {
            hasDied = true;
            SceneManager.LoadScene("MainMenu");
        }

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            hasDied = true;
            currentHealth = 0;
            theRB.velocity = Vector2.zero;
        }

        healthText.text = currentHealth.ToString() + "%";

        AudioController.instance.PlayPlayerHurt();
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthText.text = currentHealth.ToString() + "%";
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }


    public void AddSpeed(float speedMultiplier)
    {
        speedFlag = true;
        moveSpeed *= speedMultiplier;
        defaultSpeedMultiplier = speedMultiplier;
        speedText.text = (speedMultiplier*moveSpeedMultiplier).ToString() + "X";
    }

    public void ReduceSpeed()
    {
        if (moveSpeed == defaultMoveSpeed * moveSpeedMultiplier)
        {

        }
        else
        {
            moveSpeed /= defaultSpeedMultiplier;
            speedFlag = false;
            speedTime = defaultSpeedTime;
            speedText.text = moveSpeedMultiplier.ToString() + "X";
        }

    }

    public void AddMoveSpeed()
    {
        if (speedFlag == true)
        {
            moveSpeed = moveSpeed * moveSpeedMultiplier;
            speedText.text = (2 * moveSpeedMultiplier).ToString() + "X"; //СЛОМАЕТСЯ ЕСЛИ БУДЕШЬ МЕНЯТЬ СКОРОСТЬ ДАЮЩУЮСЯ ОТ ЯБЛОК
        }
        else
        {
            moveSpeed = defaultMoveSpeed * moveSpeedMultiplier;
            speedText.text = moveSpeedMultiplier.ToString() + "X";
        }
    }

    public void AddDamage()
    {
        damage = damage + 1;
        damageText.text = damage.ToString();
    }
}

