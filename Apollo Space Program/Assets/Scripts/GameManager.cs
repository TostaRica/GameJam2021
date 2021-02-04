using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public const string GAME = "SampleScene";
    public const string UPGRADES = "Upgrades";
    public const string MENU = "Menu";

    public static GameManager currentGame;

    public int highScore = 0;
    public int currency = 0;

    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (Serialization.isFileExists())
        {
            Serialization.Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = highScore.ToString();
    }

    public void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GAME);
    }

    public void upgrades()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UPGRADES);
    }    

    public void menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MENU);
    }
    
    public void exit()
    {
        Application.Quit();
    }
}
