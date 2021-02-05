using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sc_Global : MonoBehaviour
{
    public enum EndGameNum
    {
        Victory = 1,
        LoseRam = 2,
        LoseScore = 3,
    }

   
    [SerializeField] private Sc_CodeBlockGenerator cod1;
    [SerializeField] private Sc_CodeBlockGenerator cod2;
    [SerializeField] private Sc_CodeBlockGenerator cod3;
    [SerializeField] private Sc_CodeBlockGenerator cod4;
    [SerializeField] private Sc_CodeBlockGenerator cod5;
    [SerializeField] private Text txt_score;
    [SerializeField] private Text txt_combo;
    public static DataGame currentData;

    private int codeBlockCount = 0;
    private int score;
    private int maxRAM = 4;
    private int ram = 0;
    private int currency;
    private float delayTime = 0.6f;
    private float nextAction = 0.0f;
    private float finalDelay = 2.5f;
    private float finalAction = 0.0f;
    private bool endGame = false;
    private int currencyValue = 10; //points
    private Queue<int[]> level = new Queue<int[]>();

    private int currentComboMultiplier = 1;
    private int maxComboMultiplier = 5;

    private int currentComboBar = 0;
    private int maxComboBar = 10;

    // Start is called before the first frame update
    private void Start()
    {
        if (Serialization.isFileExists())
        {
            Serialization.Load();
        }
        else {
            Serialization.Save(currentData);
        }

        initLevel();
        nextAction = Time.time + delayTime;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckRam();
        txt_score.text = score.ToString();
        txt_combo.text = currentComboMultiplier.ToString();
        if (Time.time > nextAction)
        {
            nextAction = Time.time + delayTime;
            if (level.Count > 0)
            {
                generateCodeBlocks();
                increaseSpeed();
            }
        }

        if (!endGame && codeBlockCount == 0)
        {
            finalAction = Time.time + finalDelay;
            endGame = true;
        }
        if (endGame && finalAction - Time.time < 0)
        {
            EndGame(EndGameNum.Victory);
        }
    }

    private void initLevel()
    {
        int randomNumber = Random.Range(10, 20);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(1, 1));
        randomNumber = Random.Range(10, 15);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(0, 2));
        randomNumber = Random.Range(5, 10);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(1, 2));
        randomNumber = Random.Range(10, 15);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(1, 2));
        randomNumber = Random.Range(5, 10);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(0, 3));
        randomNumber = Random.Range(10, 15);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(1, 2));
        randomNumber = Random.Range(5, 10);
        codeBlockCount += randomNumber;
        generateStage(randomNumber, new Vector2(2, 3));
    }

    public void CodeBlockDestroyer(GameObject codeBlock, bool fail = false)
    {
        Destroy(codeBlock);
        codeBlockCount--;
        if (fail) ++ram;
    }

    private void generateCodeBlocks()
    {
        int[] CodeBlock = level.Dequeue();
        cod1.generate = CodeBlock[0] == 1;
        cod2.generate = CodeBlock[1] == 1;
        cod3.generate = CodeBlock[2] == 1;
        cod4.generate = CodeBlock[3] == 1;
        cod5.generate = CodeBlock[4] == 1;
    }

    private void generateStage(int codeBlockNum, Vector2 rowRange)
    {
        for (int i = 0; codeBlockNum > 0; i++)
        {
            int[] row = new[] { 0, 0, 0, 0, 0 };
            int numCodeBlocks = Random.Range((int)rowRange[0], (int)rowRange[1] + 1);
            while (numCodeBlocks > 0)
            {
                int position = (int)Random.Range(0, 5);
                if (row[position] == 0)
                {
                    row[position] = 1;
                    --numCodeBlocks;
                    --codeBlockNum;
                }
            }
            level.Enqueue(row);
        }
    }

    public void increaseSpeed()
    {
        delayTime -= 0.001f;
    }

    public float getDelayTime()
    {
        return delayTime;
    }

    public void increaseScore()
    {
        score += 1 * currentComboMultiplier * (int)currentData.actualCoffeeUpgrade; // add coffee
        if (++currentComboBar == maxComboBar)
        {
            currentComboBar = 0;
            if (currentComboMultiplier < maxComboMultiplier) ++currentComboMultiplier;
        }
    }

    public void breakCombo()
    {
        currentComboBar = 0;
        currentComboMultiplier = 1;
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void SaveDataGame()
    {
        // Serialization.Save(currentDataGame);
    }
    private void CheckRam() {
        if (ram > maxRAM + (int)currentData.actualRamUpgrade) {
            EndGame(EndGameNum.LoseRam);
        }
    }
    private void EndGame(EndGameNum endGame) {

        if (score > currentData.highScore)
        {
            currentData.highScore = score;
        }
        currentData.currency = GetCoins();
        Serialization.Save(currentData);

        switch (endGame) {
            case EndGameNum.Victory:
                Menu();
                break;
            case EndGameNum.LoseRam:
                Menu();
                break;
            case EndGameNum.LoseScore:
                Menu();
                break;
        }

    }
    internal static void SetDataGame(DataGame datagame) {
        currentData = datagame;
    }
    private int GetCoins() {

        return (int) score/currencyValue; 
    }




}