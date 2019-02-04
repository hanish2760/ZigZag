using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnner : MonoBehaviour {
    public GameObject platform;
    public GameObject daimond;
    Vector3 lastpos;
    float size;
    public bool gameover;
	// Use this for initialization
	void Start () {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;
       for(int i = 0; i < 2; i++)
        {
            spawnner();

        }
    }
    public void startspwanning()
    {
        InvokeRepeating("spawnner", 0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.instance.gameover==true)
        {
            CancelInvoke("spawnner");
        }
        
	}
    void spawnner()
    {
        int r = Random.Range(0, 6);
        if (r < 3)
        {
            spawnX();

        }
        else
        {
            spawnZ();
        }
    }
    void spawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            spawnDiamond(pos);
        }
    }
    void spawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            spawnDiamond(pos);
        }
    }
    void spawnDiamond(Vector3 pos)
    {
        Instantiate(daimond,new Vector3 ( pos.x,pos.y+1,pos.z),daimond.transform.rotation );
    }
}
