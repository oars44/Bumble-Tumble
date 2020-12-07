using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBeeSpawner : MonoBehaviour {

    public GameObject fakeBee;

	void Start ()
    {
        InvokeRepeating("spawn", 0f, 3f);
	}
	
	void Update ()
    {
		
	}

    void spawn()
    {
        float pos = Random.Range(-3, 3);

        Instantiate(fakeBee, new Vector3(pos, 6, 0), new Quaternion(0, 0, 0, 0));

    }
}
