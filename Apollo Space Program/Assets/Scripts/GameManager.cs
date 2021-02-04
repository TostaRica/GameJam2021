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

    public Text highScoreText;
    public Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Entro en el GameManager");
        if (Serialization.isFileExists())
        {
            Serialization.Load();
        } else
        {
            Serialization.Save(currentDataGame);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (highScoreText.text != null)
        {
            highScoreText.text = currentDataGame.highScore.ToString();
        }
        
        if (currencyText.text != null)
        {
            currencyText.text = currentDataGame.currency.ToString();
        }
  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
            
    }

    public void AddHighScore ()
    {
        currentDataGame.highScore += 100;
    }

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
}
