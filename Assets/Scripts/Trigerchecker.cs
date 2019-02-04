using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigerchecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
           Invoke("fallDown",0.5f);
        }
    }
    void fallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
