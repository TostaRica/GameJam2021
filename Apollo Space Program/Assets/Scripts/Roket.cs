using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    public float TimeToLaunch;
    public float TimeToExplote;
    public AudioSource AudioRoket;
    public AudioSource RocketExplote;
    public bool isLaunched;
    public bool levelEnd;
    public bool isDestroy;
    public bool HasBeenDestroy;
    public float timeToScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy)
        {
            DestroyRoket();
        }
        if (levelEnd)
        {
            LaunchRoket();
        }
    }

    public void DestroyRoket()
    {
        if (TimeToLaunch > 0)
        {
            TimeToLaunch -= Time.deltaTime;
        }
        else
        {
            gameObject.transform.Translate(Vector3.up * 20 * Time.deltaTime);
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

            if (TimeToExplote > 0)
            {
                TimeToExplote -= Time.deltaTime;
            }
            else {
                if (!HasBeenDestroy)
                {
                    GameObject[] RoketExplote;
                    RoketExplote = GameObject.FindGameObjectsWithTag("RExplode");
                    foreach (GameObject go in RoketExplote)
                    {
                        go.GetComponentInChildren<ParticleSystem>().Play();
                    }

                    GameObject[] RoketChild;
                    RoketChild = GameObject.FindGameObjectsWithTag("Child");
                    foreach (GameObject go in RoketChild)
                    {
                        go.GetComponentInChildren<Rigidbody>().isKinematic = false;
                    }
                    HasBeenDestroy = true;
                    RocketExplote.Play();
                    RoketFires = GameObject.FindGameObjectsWithTag("Rfire");
                    foreach (GameObject go in RoketFires)
                    {
                        go.GetComponentInChildren<ParticleSystem>().Stop();
                    }

                   
                }
            }
            if((HasBeenDestroy))
            {
                timeToScene -= Time.deltaTime;
                if(timeToScene < 0)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                }
            }
        }
    }


    public void LaunchRoket()
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
            if ((isLaunched))
            {
                timeToScene -= Time.deltaTime;
                if (timeToScene < 0)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
