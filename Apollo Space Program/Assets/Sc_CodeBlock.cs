using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CodeBlock : MonoBehaviour
{
    public Vector3 direction;
    public bool speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed) {
            gameObject.transform.position += direction * Time.deltaTime; 
        }
    }
}
