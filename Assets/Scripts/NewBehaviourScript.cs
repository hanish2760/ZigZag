using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NewBehaviourScript : MonoBehaviour {
    public float vel;
    public float sen = 75;
    public float loudness = 0;
    AudioSource _as;
    public float speed;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public AudioMixerGroup audiomixergrp;
	// Use this for initialization
	void Start () {
        _as = GetComponent<AudioSource>();
        if (Microphone.devices.Length > 0)
        {
            _as.outputAudioMixerGroup = audiomixergrp;
            _as.clip = Microphone.Start(null, true,3, 44100);
            if (_as.clip == null)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
            }
            _as.loop = true;
            //      _as.mute = true;
            while (!(Microphone.GetPosition(null) > 0))
            {

            }
            _as.Play();
        }

	}
	
	// Update is called once per frame
	void Update () {
    
        loudness = Avg() * sen;
       
        /*if (loudness>5 && loudness < 10)
         {
            Debug.Log(loudness);
            //moveForward();
         }
         else if(loudness>15)
         {
            Debug.Log(loudness);
            SwitchDirection();
         }
         else {

         }*/
        if (loudness > 9)
        {
            
            SwitchDirection();
        }
        loudness = Avg() * sen;
        while (loudness != 0)
        {
            loudness = Avg() * sen;
            if (loudness == 0)
            {
                break;
            }
        }
    }
    float Avg()
    {
        float[] d = new float[256];
        float a = 0;
        _as.GetOutputData(d, 0);
        foreach(float s in d)
        {
            a += Mathf.Abs(s);
      
        }
        return a / 256;

    }
    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    void moveForward()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
