using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CodeBlock : MonoBehaviour
{
    public Vector3 direction;
    public Sc_Global global;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (direction * Time.deltaTime) / global.getDelayTime();
    }
}
