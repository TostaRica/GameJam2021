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
    public Button TwoRamBtn;
    public Button FourRamBtn;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Entro en el GameManager");
        if (Serialization.isFileExists())
        {
            Serialization.Load();
        } else
        {
            Serialization.Save(currentDataGame);
        }

        // Upgrades buttons
        colombianCoffeeBtn.interactable = false;
        mexicanCoffeeBtn.interactable = false;
        TwoRamBtn.interactable = false;
        FourRamBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = currentDataGame.highScore.ToString();
        currencyText.text = currentDataGame.currency.ToString();
        actualCoffeeUpgradeText.text = currentDataGame.actualCoffeeUpgrade.ToString();
        actualRamUpgradeText.text = currentDataGame.actualRamUpgrade.ToString();

        UpdateButtonsUpgrade();
  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
            
    }

    public void AddHighScore ()
    {
        currentDataGame.highScore += 100;
    }    
    public void AddCurrency ()
    {
        currentDataGame.currency += 10;
    }

    // Methods to flow
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME);
    }

    public void Upgrades()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UPGRADES);
    }    

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MENU);
    }
    
    public void Exit()
    {
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
        currentDataGame.currency -= 10;
        currentDataGame.actualCoffeeUpgrade = UpgradeCoffeeCode.Colombian;
    }

    public void GetTwoRAMUpgrade()
    {
        currentDataGame.currency -= 30;
        currentDataGame.actualRamUpgrade = UpgradeRamCode.TwoKB;
    }

    public void GetMexicanCoffeeUpgrade()
    {
        currentDataGame.currency -= 10;
        currentDataGame.actualCoffeeUpgrade = UpgradeCoffeeCode.Mexican;
    }    
    
    public void GetFourRAMUpgrade()
    {
        currentDataGame.currency -= 30;
        currentDataGame.actualRamUpgrade = UpgradeRamCode.FourKB;
    }

    private void UpdateButtonsUpgrade()
    {
        if (currentDataGame.actualCoffeeUpgrade == UpgradeCoffeeCode.None && currentDataGame.currency > 10)
        {
            colombianCoffeeBtn.interactable = true;
        } else if (currentDataGame.actualCoffeeUpgrade == UpgradeCoffeeCode.Colombian)
        {
            colombianCoffeeBtn.Select();
            if (currentDataGame.currency > 30)
            {
                mexicanCoffeeBtn.interactable = true;
            }    
        }

        if (currentDataGame.actualRamUpgrade == UpgradeRamCode.None && currentDataGame.currency > 10)
        {
            TwoRamBtn.interactable = true;
        }
        else if (currentDataGame.actualRamUpgrade == UpgradeRamCode.TwoKB)
        {
            TwoRamBtn.Select();
            if (currentDataGame.currency > 30)
            {
                FourRamBtn.interactable = true;
            }
        }
    }

}
