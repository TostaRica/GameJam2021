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
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.2f, gameObject.transform.position.z);
            if (codeblock != null)
            {
                Destroy(codeblock);
                global.increaseScore();
                codeblock = null;
                //add points
            }
            else
            {
                global.breakCombo();
                //quitar puntos 
            }
        }
        if (Input.GetKeyUp(key))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
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
