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

    public int highScore = currentDataGame.highScore;
    public int currency = currentDataGame.currency;

    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
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
        highScoreText.text = currentDataGame.highScore.ToString();
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
