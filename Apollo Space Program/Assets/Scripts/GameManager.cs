using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public const string GAME = "SampleScene";
    public const string UPGRADES = "Upgrades";
    public const string MENU = "Menu";

    public static DataGame currentDataGame = new DataGame();

    // Data Game Info
    public Text highScoreText;
    public Text currencyText;
    public Text actualCoffeeUpgradeText;
    public Text actualRamUpgradeText;

    // Upgrades buttons
    public Button colombianCoffeeBtn;
    public Button mexicanCoffeeBtn;
    public Button americanCoffeeBtn;
    public Button TwoRamBtn;
    public Button FourRamBtn;
    public Button SixRamBtn;

    //Audio
    public AudioSource audio;
    public AudioSource coffe;
    public AudioSource ram;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Entro en el GameManager");
        if (Serialization.isFileExists())
        {
            Serialization.Load();
        }
        else
        {
            Serialization.Save(currentDataGame);
        }



        // Upgrades buttons
        colombianCoffeeBtn.interactable = false;
        mexicanCoffeeBtn.interactable = false;
        americanCoffeeBtn.interactable = false;
        TwoRamBtn.interactable = false;
        FourRamBtn.interactable = false;
        SixRamBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = currentDataGame.highScore.ToString();
        currencyText.text = currentDataGame.currency.ToString();
        actualCoffeeUpgradeText.text = currentDataGame.actualCoffeeUpgrade.ToString();
        actualRamUpgradeText.text = currentDataGame.actualRamUpgrade.ToString();

        if (Application.loadedLevelName != MENU) // Menu Index 0
        {
            UpdateButtonsUpgrade();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void AddHighScore()
    {
        currentDataGame.highScore += 100;
    }
    public void AddCurrency()
    {
        currentDataGame.currency += 10;
    }

    // Methods to flow
    public void Play()
    {
        audio.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME);
    }

    public void Upgrades()
    {
        audio.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UPGRADES);
    }

    public void Menu()
    {
   
        UnityEngine.SceneManagement.SceneManager.LoadScene(MENU);
        SaveDataGame();
    }

    public void Exit()
    {
        audio.Play();
        Application.Quit();
    }

    // Methods Serialization

    public void SaveDataGame()
    {
        Serialization.Save(currentDataGame);
    }

    public void LoadDataGame()
    {
        Serialization.Load();
    }

    internal static void SetDataGame(DataGame loadDataGame)
    {
        currentDataGame = loadDataGame;
    }

    // Methods Upgrades
    public void GetColombianCoffeeUpgrade()
    {
        coffe.Play();
        currentDataGame.currency -= 10;
        currentDataGame.actualCoffeeUpgrade = UpgradeCoffeeCode.Colombian;
    }

    public void GetMexicanCoffeeUpgrade()
    {
        coffe.Play();
        currentDataGame.currency -= 30;
        currentDataGame.actualCoffeeUpgrade = UpgradeCoffeeCode.Mexican;
    }    
    
    public void GetAmericanCoffeeUpgrade()
    {
        coffe.Play();
        currentDataGame.currency -= 60;
        currentDataGame.actualCoffeeUpgrade = UpgradeCoffeeCode.American;
    }

    public void GetTwoRAMUpgrade()
    {
        ram.Play();
        currentDataGame.currency -= 10;
        currentDataGame.actualRamUpgrade = UpgradeRamCode.TwoKB;
    }

    public void GetFourRAMUpgrade()
    {
        ram.Play();
        currentDataGame.currency -= 30;
        currentDataGame.actualRamUpgrade = UpgradeRamCode.FourKB;
    }
    
    public void GetSixRAMUpgrade()
    {
        ram.Play();
        currentDataGame.currency -= 60;
        currentDataGame.actualRamUpgrade = UpgradeRamCode.SixKB;
    }

    private void UpdateButtonsUpgrade()
    {
        if (currentDataGame.actualCoffeeUpgrade == UpgradeCoffeeCode.None)
        {
            colombianCoffeeBtn.gameObject.SetActive(true);
            colombianCoffeeBtn.interactable = currentDataGame.currency > 10 ? true : false;
        } else if (currentDataGame.actualCoffeeUpgrade == UpgradeCoffeeCode.Colombian)
        {
            colombianCoffeeBtn.gameObject.SetActive(false);
            mexicanCoffeeBtn.gameObject.SetActive(true);
            mexicanCoffeeBtn.interactable = currentDataGame.currency > 30 ? true : false;
        } else if (currentDataGame.actualCoffeeUpgrade == UpgradeCoffeeCode.Mexican)
        {
            colombianCoffeeBtn.gameObject.SetActive(false);
            mexicanCoffeeBtn.gameObject.SetActive(false);
            americanCoffeeBtn.gameObject.SetActive(true);
            americanCoffeeBtn.interactable = currentDataGame.currency > 60 ? true : false;
        } else if (currentDataGame.actualCoffeeUpgrade == UpgradeCoffeeCode.American)
        {
            colombianCoffeeBtn.gameObject.SetActive(false);
            mexicanCoffeeBtn.gameObject.SetActive(false);
            americanCoffeeBtn.gameObject.SetActive(false);
        }
        if (currentDataGame.actualRamUpgrade == UpgradeRamCode.None)
        {
            TwoRamBtn.gameObject.SetActive(true);
            TwoRamBtn.interactable = currentDataGame.currency > 10 ? true : false;
        }
        else if (currentDataGame.actualRamUpgrade == UpgradeRamCode.TwoKB)
        {
            TwoRamBtn.gameObject.SetActive(false);
            FourRamBtn.gameObject.SetActive(true);
            FourRamBtn.interactable = currentDataGame.currency > 30 ? true : false;
        }
        else if (currentDataGame.actualRamUpgrade == UpgradeRamCode.FourKB)
        {
            TwoRamBtn.gameObject.SetActive(false);
            FourRamBtn.gameObject.SetActive(false);
            SixRamBtn.gameObject.SetActive(true);
            SixRamBtn.interactable = currentDataGame.currency > 60 ? true : false;
        }
        else if (currentDataGame.actualRamUpgrade == UpgradeRamCode.SixKB)
        {
            TwoRamBtn.gameObject.SetActive(false);
            FourRamBtn.gameObject.SetActive(false);
            SixRamBtn.gameObject.SetActive(false);
        }
    }
}
