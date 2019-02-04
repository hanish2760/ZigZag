using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConroll : MonoBehaviour {
    [SerializeField]
    private float speed;
    Rigidbody rb;
    bool gameover;
    bool started;
    public GameObject particle;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        gameover = false;
        started = false;
        	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(0, 0, 0);
                started = true;
                GameManager.instance.GameStart();
                
            }

        }
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameover = true;
            // speed = -25;
            rb.velocity = new Vector3(0, -25, 0);
            Camera.main.GetComponent<CameraFollow>().gameover = true;
            GameManager.instance.GameOver();
        }
        if (Input.GetMouseButtonDown(0) && !gameover)
        {
            SwitchDirection();
        }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Diamond"))
        {

            GameObject part =   Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(part, 0.8f);
            Destroy(other.gameObject);
            
          

        }
    }
}
