using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CodeBlockGenerator : MonoBehaviour
{
    public Sc_CodeBlock model;
    public Vector3 position = new Vector3(-2,0,0);
    public bool generate = false;
    Vector3 direction = new Vector3(1,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generate) {
            //generate code
            Sc_CodeBlock obj = Sc_CodeBlock.Instantiate(model);
            obj.transform.position = position;
            obj.direction = direction;
            obj.speed = true;
            generate = false;
        }
    }
}
