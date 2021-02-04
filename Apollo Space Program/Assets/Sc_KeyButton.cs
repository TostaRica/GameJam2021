using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_KeyButton : MonoBehaviour
{
    [SerializeField] KeyCode key;
    GameObject codeblock = null;
    [SerializeField] Sc_Global global = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (codeblock != null)
            {
                Destroy(codeblock);
                global.increaseScore();
                //add points
            }
            else
            {
                global.breakCombo();
                //quitar puntos 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CodeBlock"))
        {
            codeblock = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CodeBlock"))
        {
            codeblock = null;
        }
    }

}
