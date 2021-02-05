using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CodeBlockDestroyer : MonoBehaviour
{
    [SerializeField] private Sc_Global global = null;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CodeBlock"))
        {
            global.CodeBlockCountDestroyer(other.gameObject);
        }
    }
}