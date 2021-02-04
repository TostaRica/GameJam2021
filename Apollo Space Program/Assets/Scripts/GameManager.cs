using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const string GAME = "SampleScene";
    public const string UPGRADES = "Upgrades";
    public const string MENU = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
