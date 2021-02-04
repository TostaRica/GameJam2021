using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Global : MonoBehaviour
{

    public int maxRAM; //numnero de intentos
    public int coffe;  //score multiplier

    int score;
    int ram;
    int currency;
    float speed = 0.6f;
    float nextAction = 0;

    Queue<int[]> level = new Queue<int[]>();

    public Sc_CodeBlockGenerator cod1;
    public Sc_CodeBlockGenerator cod2;
    public Sc_CodeBlockGenerator cod3;
    public Sc_CodeBlockGenerator cod4;
    public Sc_CodeBlockGenerator cod5;

    // Start is called before the first frame update
    void Start()
    {
        initLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAction) {
            nextAction = Time.time + speed;
            if(level.Count > 0) generateCodeBlocks();
        }
    }

    float GetSpeed() {
        return speed;
    }

    void initLevel() {

        //bool,bool,bool,bool,bool,set speed (0 dont change the speed)
        level.Enqueue(new[] { 1, 0, 0, 0, 0, 1 }); //level starts;
        level.Enqueue(new[] { 0, 1, 0, 0, 0, 0 });
        level.Enqueue(new[] { 0, 0, 1, 0, 0, 0 });
        level.Enqueue(new[] { 0, 0, 0, 1, 0, 0 });
        level.Enqueue(new[] { 0, 0, 0, 0, 1, 0 });
        //level.Enqueue(new[] { 0, 0, 0, 0, 0, 0 });

    }
    void generateCodeBlocks() {
        int[] CodeBlock = level.Dequeue();
        cod1.generate = CodeBlock[0] == 1;
        cod2.generate = CodeBlock[1] == 1;
        cod3.generate = CodeBlock[2] == 1;
        cod4.generate = CodeBlock[3] == 1;
        cod5.generate = CodeBlock[4] == 1;
    }
}
