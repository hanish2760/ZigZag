using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public float vel;
    Rigidbody rb;
    public float sensitivity=100;
    public float loudness;
    AudioSource audios;
    // Use this for initialization
    void Start () {
        audios = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        audios.clip= Microphone.Start(null, true, 10, 44100);
        audios.loop = true;
        audios.mute = true;
        while (!(Microphone.GetPosition(null)>0) )
        {

        }
        audios.Play();
	}
	
	// Update is called once per frame
	void Update () {
        loudness = Avg() * sensitivity;
        if (loudness > 0)
        {
            rb.velocity = new Vector3(0, vel, 0);
        }
	}
    float Avg()
    {
        float[] data = new float[256];
        float a = 0;
        audios.GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);

        }
        return a / 256;

    }
}
