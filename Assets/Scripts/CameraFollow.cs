using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Vector3 offset;//distance between cam and object
    public bool gameover;
    public float lerprate;
    public GameObject ball;
	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
        gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameover)
        {
            Follow();
        }
	}
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetpos, lerprate);
        transform.position = pos;

    }
}
