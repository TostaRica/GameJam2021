using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourObjects : MonoBehaviour
{
    public GameObject coffeeMug;
    public static DataGame currentDataGame;

    // Start is called before the first frame update
    void Start()
    {
        Serialization.Load();
    }

    // Update is called once per frame
    void Update()
    {
        bool isUpgradeCoffee = (currentDataGame.actualCoffeeUpgrade != UpgradeCoffeeCode.None) ? true : false;
        coffeeMug.gameObject.SetActive(isUpgradeCoffee);
    }

    internal static void SetDataGame(DataGame dataGame)
    {
        currentDataGame = dataGame;
    }
}
