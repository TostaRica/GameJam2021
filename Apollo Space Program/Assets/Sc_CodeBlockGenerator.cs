using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CodeBlockGenerator : MonoBehaviour
{
    [SerializeField] private Sc_CodeBlock model;
    [SerializeField] private Sc_Global global;
    public bool generate = false;

    private Vector3 direction = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (generate)
        {
            //generate code
            Sc_CodeBlock obj = Sc_CodeBlock.Instantiate(model);
            obj.transform.position = transform.position;
            obj.direction = direction;
            obj.global = global;
            generate = false;
        }
    }
}