//Time.timeScale = 0f; задел на остановку времени/паузу
//ПОЧЕМУ ЯБЛОКИ НЕ ДАЮТ СКОРОСТЬ НА 1.3 УСКОРЕНИИ????????
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
    public float defaultMoveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;
    public Animator anim; // walk anim

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    public GameObject deadApocScreen;
    public GameObject deadDamageScreen;
    public GameObject winScreen;
    public GameObject startScreen;
    public GameObject secretScreen;
    public GameObject secretBossScreen;
    public GameObject kidRewardScreen;
    public bool hasDied;

    public Text healthText, ammoText, speedText, damageText;

    public GameObject bullet;
    public Transform firePoint; //где спавнить пулю
    public int damage = 1;

    public float speedTime = 3f;
    public bool speedFlag = false;
    //public float defaultSpeedMultiplier;
    public float defaultSpeedTime = 3f;
    public float moveSpeedMultiplier = 1f;
    public float currentSpeed;
    private short appleBoost = 2;

    public int secretCounter;
    public int amountOfSecrets;

    public int killCounter;
    public int amountOfKills = 24;
    public int kidCounter;
    public int amountOfKids = 10;

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

    public float timer = 0; public float timer2 = 0; public float timer3 = 0; //because i'm a dumbass
    public float apocalypseTimer;

    public GameObject secretBoss; 

    bool secretBossSpawned = false;

    public string currentLevel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";
        ammoText.text = currentAmmo.ToString();
        speedText.text = moveSpeedMultiplier.ToString() + "X";
        currentLevel = SceneManager.GetActiveScene().name;
        switch (currentLevel)
        {
            case "jungle":
                amountOfSecrets = 2;
                bossAmount = 1;
                amountOfKids = 10;
                amountOfKills = 24;
                PlayerPrefs.DeleteKey("jungleKills100");
                PlayerPrefs.DeleteKey("jungleKids100");
                break;
            case "dreamcast":
                amountOfSecrets = 3;
                bossAmount = 1;
                if (PlayerPrefs.HasKey("jungleKids100") && PlayerPrefs.HasKey("jungleKills100"))
                {
                    damage += 2;
                    moveSpeedMultiplier += 0.2f;
                    speedText.text = moveSpeedMultiplier.ToString() + "X";
                    damageText.text = damage.ToString();
                    startScreen.SetActive(true);
                }
                amountOfKills = 1;
                amountOfKids = 2;
                killCounter = 0;
                kidCounter = 0;
                break;
            case "tutor":
                currentHealth = 75;
                break;
        }
        secretCounter = 0;
        killCounter = 0;
        kidCounter = 0;
        bossCounter = 0;
        winCube.SetActive(false);
        if (PlayerPrefs.HasKey("MouseSens"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSens") / 100;
        }
        else mouseSensitivity = 1f;
        //AudioController.instance.PlayBackGroundMusic();
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
            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed; //* Time.deltaTime;

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
            //высчитываем скорость учитывая яблоки и ускорения от детей
            currentSpeed = defaultMoveSpeed * moveSpeedMultiplier;
            //анимация хождения, наверно
            if (moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
            //выключение ускорения от яблока по таймеру
            if (speedFlag == true)
            {
                speedTime -= Time.deltaTime;
                if (speedTime <= 0)
                {
                    ReduceSpeed();
                }
            }
            //считаем очки
            score = (killCounter * 500) + (kidCounter * 1000) + (18000 - (int)((Time.timeSinceLevelLoad) * 100)) + (secretCounter * 3000) + (bossCounter * 10000);
            //спавн винкуба и победной надписи
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
            //второй босс
            if (killCounter >= amountOfKills)
            {
                if (secretBossSpawned == false)
                {
                    secretBossSpawned = true;
                    secretBoss.SetActive(true);
                    //jungleKills100 = true;
                    PlayerPrefs.SetInt("jungleKills100", 1);
                }              
                secretBossScreen.SetActive(true);
                if (timer2 < 3f)
                {
                    timer2 += Time.deltaTime;
                }
                else if (timer2 >= 3f)
                {
                    secretBossScreen.SetActive(false);
                    timer2 = 3.1f;
                }
            }
            //бонусы за сбор всех детей
            if (kidCounter >= amountOfKids)
            {
                kidRewardScreen.SetActive(true);
                //jungleKids100 = true;
                PlayerPrefs.SetInt("jungleKids100", 1);
                if (timer3 < 3f)
                {
                    timer3 += Time.deltaTime;
                }
                else if (timer3 >= 3f)
                {
                    kidRewardScreen.SetActive(false);
                    timer3 = 3.1f;
                }
            }
        }
        else
        {
            winScreen.SetActive(false);
            secretScreen.SetActive(false);
            secretBossScreen.SetActive(false);
            kidRewardScreen.SetActive(false);
            winCubeScreen.SetActive(false);
            startScreen.SetActive(false);
        }


        //рестарт левела
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Restart", "F"))))
        {
            switch (currentLevel)
            {
                case "jungle":
                    PlayerPrefs.DeleteKey("jungleKills100");
                    PlayerPrefs.DeleteKey("jungleKids100");
                    SceneManager.LoadScene(currentLevel);
                    break;
                case "dreamcast":
                    SceneManager.LoadScene(currentLevel);
                    break;
                case "tutor":
                    SceneManager.LoadScene(currentLevel);
                    break;
            }
        }
        //возвращение в главное меню
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Exit", "Escape"))))
        {
            hasDied = true;
            PlayerPrefs.DeleteKey("jungleKills100");
            PlayerPrefs.DeleteKey("jungleKids100");
            SceneManager.LoadScene("MainMenu");
        }

        if (SceneManager.GetActiveScene().name != "tutor" && hasDied == false)
        {
            // gamover при достижении минуты
            apocalypseTimer = Time.timeSinceLevelLoad * 100;

            if (apocalypseTimer > 6000)
            {
                TakeDamage(101);
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            deadDamageScreen.SetActive(true);
            if (currentHealth == -1)
            {
                deadDamageScreen.SetActive(false);
                deadApocScreen.SetActive(true);
            }
            hasDied = true;
            currentHealth = 0;
            apocalypseTimer = 0;
            theRB.velocity = Vector2.zero;
            AudioController.instance.backgroundMusic.Stop();
            AudioController.instance.loseSound.Play();
        }
        else
        {
            healthText.text = currentHealth.ToString() + "%";
            AudioController.instance.PlayPlayerHurt();
        }
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


    public void AddSpeed()
    {
        speedFlag = true;
        moveSpeed *= appleBoost;
        speedText.text = (appleBoost*moveSpeedMultiplier).ToString() + "X";
    }

    public void ReduceSpeed()
    {
        if (moveSpeed == defaultMoveSpeed * moveSpeedMultiplier)
        {

        }
        else
        {
            moveSpeed /= appleBoost;
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
            speedText.text = (appleBoost * moveSpeedMultiplier).ToString() + "X";
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

    public void Add3Damage()
    {
        damage = damage + 2;
        damageText.text = damage.ToString();
    }
}

