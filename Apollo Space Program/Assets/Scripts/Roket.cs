using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    public float TimeToLaunch;
    public AudioSource AudioRoket;
    public bool isLaunched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (TimeToLaunch > 0)
        {
            TimeToLaunch -= Time.deltaTime;
        }
        else
        {
            
           gameObject.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            GameObject[] RoketFires;
            RoketFires = GameObject.FindGameObjectsWithTag("Rfire");
            foreach (GameObject go in RoketFires)
            {
                go.GetComponentInChildren<ParticleSystem>().Play();
            }
            if (!isLaunched)
            {
                isLaunched = true;
                AudioRoket.Play();
            }
        }
    }
}
