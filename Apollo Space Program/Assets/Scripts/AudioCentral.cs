using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCentral : MonoBehaviour
{
    public float TimeToStart;
    public AudioSource audio;
    public bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeToStart > 0)
        {
            TimeToStart -= Time.deltaTime;
        }
        else
        {
            if (!isStart)
            {
                isStart = true;
                audio.Play();
            }
        }
    }
}
