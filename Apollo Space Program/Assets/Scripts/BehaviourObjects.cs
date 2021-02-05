using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourObjects : MonoBehaviour
{
    public GameObject coffeeMug;
    public static DataGame currentDataGame = new DataGame();

    // Start is called before the first frame update
    private void Start()
    {
        if (Serialization.isFileExists())
        {
            Serialization.Load();
        }
        else
        {
            Serialization.Save(currentDataGame);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        coffeeMug.gameObject.SetActive(currentDataGame.actualCoffeeUpgrade != UpgradeCoffeeCode.None);
    }

    internal static void SetDataGame(DataGame dataGame)
    {
        currentDataGame = dataGame;
    }
}