using System.Collections;
using UnityEngine;

public enum UpgradesCoffeeCode
{
    None,
    Colombian, //x2
    Mexican, //x3
    American //x4
}
public enum UpgradesRamCode
{
    None,
    TwoKB, //+2
    FourKB, //+4
    SixKB //+6
}

[System.Serializable]
public class DataGame
{   

    public int highScore;
    public int currency;
    public UpgradesCoffeeCode actualCoffeeUpgrade;
    public UpgradesRamCode actualRamUpgrade;

    public DataGame()
    {
        highScore = 0;
        currency = 1;
        actualCoffeeUpgrade = UpgradesCoffeeCode.None;
        actualRamUpgrade = UpgradesRamCode.None;
    }



}
