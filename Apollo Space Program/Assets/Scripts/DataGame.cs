using System.Collections;
using UnityEngine;

public enum UpgradeCoffeeCode
{
    None = 1,
    Colombian = 2, //x2
    Mexican = 3, //x3
    American = 4 //x4
}
public enum UpgradeRamCode
{
    None = 0,
    TwoKB = 2, //+2
    FourKB = 4, //+4
    SixKB = 6 //+6
}

[System.Serializable]
public class DataGame
{   

    public int highScore;
    public int currency;
    public UpgradeCoffeeCode actualCoffeeUpgrade;
    public UpgradeRamCode actualRamUpgrade;

    public DataGame()
    {
        highScore = 0;
        currency = 1;
        actualCoffeeUpgrade = UpgradeCoffeeCode.None;
        actualRamUpgrade = UpgradeRamCode.None;
    }



}
