using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_Global : MonoBehaviour
{
    [SerializeField] private int maxRAM; //numnero de intentos
    [SerializeField] private int coffe;  //score multiplier
    [SerializeField] private Sc_CodeBlockGenerator cod1;
    [SerializeField] private Sc_CodeBlockGenerator cod2;
    [SerializeField] private Sc_CodeBlockGenerator cod3;
    [SerializeField] private Sc_CodeBlockGenerator cod4;
    [SerializeField] private Sc_CodeBlockGenerator cod5;
    [SerializeField] private Text txt_score;
    [SerializeField] private Text txt_combo;

    private int codeBlockCount = 0;
    private int score;
    private int ram;
    private int currency;
    private float delayTime = 0.52f;
    private float nextAction = 0.0f;
    private float finalDelay = 2.5f;
    private float finalAction = 0.0f;
    private bool endGame = false;

    private Queue<int[]> level = new Queue<int[]>();

    private int currentComboMultiplier = 1;
    private int maxComboMultiplier = 5;

    private int currentComboBar = 0;
    private int maxComboBar = 10;

    // Start is called before the first frame update
    private void Start()
    {
        initLevel();
        nextAction = Time.time + delayTime;
    }

    // Update is called once per frame
    private void Update()
    {

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
            Menu();
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

    public void CodeBlockCountDestroyer(GameObject codeBlock)
    {
        Destroy(codeBlock);
        codeBlockCount--;
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
        delayTime -= 0f;
    }

    public float getDelayTime()
    {
        return delayTime;
    }

    public void increaseScore()
    {
        score += 1 * currentComboMultiplier; // add coffee
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
}