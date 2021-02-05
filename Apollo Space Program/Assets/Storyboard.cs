using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyboard : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
        }
    }
    
}
