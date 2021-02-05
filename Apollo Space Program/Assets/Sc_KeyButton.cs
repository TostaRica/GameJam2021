using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_KeyButton : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    private GameObject codeblock = null;
    [SerializeField] private Sc_Global global = null;


    public ParticleSystem[] particles = new ParticleSystem[2];
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
            if (codeblock != null)
            {
                particles[0].Play();
                particles[1].Play();
                global.CodeBlockCountDestroyer(codeblock);
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
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
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