using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Global : MonoBehaviour
{
    [SerializeField] int maxRAM; //numnero de intentos
    [SerializeField] int coffe;  //score multiplier
    [SerializeField] Sc_CodeBlockGenerator cod1;
    [SerializeField] Sc_CodeBlockGenerator cod2;
    [SerializeField] Sc_CodeBlockGenerator cod3;
    [SerializeField] Sc_CodeBlockGenerator cod4;
    [SerializeField] Sc_CodeBlockGenerator cod5;

    private int score;
    private int ram;
    private int currency;
    private float speed = 0.6f;
    private float nextAction = 0.0f;

    private Queue<int[]> level = new Queue<int[]>();

    // Start is called before the first frame update
    private void Start()
    {
        initLevel();
        nextAction = Time.time + speed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > nextAction)
        {
            nextAction = Time.time + speed;
            if (level.Count > 0) generateCodeBlocks();
        }
    }

    private float GetSpeed()
    {
        return speed;
    }

    private void initLevel()
    {
        //bool,bool,bool,bool,bool,set speed (0 dont change the speed)
        level.Enqueue(new[] { 1, 0, 0, 0, 0, 1 }); //level starts;
        level.Enqueue(new[] { 0, 1, 0, 0, 0, 0 });
        level.Enqueue(new[] { 0, 0, 1, 0, 0, 0 });
        level.Enqueue(new[] { 0, 0, 0, 1, 0, 0 });
        level.Enqueue(new[] { 0, 0, 0, 0, 1, 0 });
        //level.Enqueue(new[] { 0, 0, 0, 0, 0, 0 });

        level.Enqueue(new[] { 0, 0, 0, 0, 1, 1 });
        level.Enqueue(new[] { 0, 0, 0, 1, 0, 0 });
        level.Enqueue(new[] { 0, 0, 1, 0, 0, 0 });
        level.Enqueue(new[] { 0, 1, 0, 0, 0, 0 });
        level.Enqueue(new[] { 1, 0, 0, 0, 0, 0 });
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
}