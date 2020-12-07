using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

    public GameObject honey;
    public GameObject wasp;
    public float vertTime = 4f;
    public float horStartTime = 15f;
    public float horTime = 4f;
    public float waspStartTime = 10f;
    public float waspTime = 5f;

	void Start ()
    {
        InvokeRepeating("VertHoney", 2f, vertTime);
        InvokeRepeating("HorHoney", horStartTime, horTime);

        InvokeRepeating("VertWasp", waspStartTime, waspTime);
        InvokeRepeating("HorWasp", waspStartTime + 10f, waspTime);
	}
	
	void Update ()
    {
		


	}

    void VertHoney()
    {

        float dir = Random.value;

        if(dir >.5f)
        {
            float pos = Random.Range(-2.3f, 2.3f);

            GameObject newComb = Instantiate(honey, new Vector3(pos, 6, 0), new Quaternion(0, 0, 0, 0));

            HoneyController comb = newComb.GetComponent<HoneyController>();
            comb.dir = Vector3.down;
        }

        if(dir <=.5)
        {
            float pos = Random.Range(-2.3f, 2.3f);

           GameObject newComb = Instantiate(honey, new Vector3(pos, -6, 0), new Quaternion(0, 0, 0, 0));

            HoneyController comb = newComb.GetComponent<HoneyController>();
            comb.dir = Vector3.up;
        }

    }

    void HorHoney()
    {

        float dir = Random.value;

        if (dir > .5f)
        {
            float pos = Random.Range(-1.65f, 1.65f);

            GameObject newComb = Instantiate(honey, new Vector3(4, pos, 0), new Quaternion(0, 0, 0, 0));

            HoneyController comb = newComb.GetComponent<HoneyController>();
            comb.dir = Vector3.left;
        }

        if (dir <= .5)
        {
            float pos = Random.Range(-1.65f, 1.65f);

            GameObject newComb = Instantiate(honey, new Vector3(-4, pos, 0), new Quaternion(0, 0, 0, 0));

            HoneyController comb = newComb.GetComponent<HoneyController>();
            comb.dir = Vector3.right;
        }

    }

    void VertWasp()
    {
        float dir = Random.value;

        if (dir > .5f)
        {
            float pos = Random.Range(-2.3f, 2.3f);

            float flip = Random.value;

            GameObject newbug = Instantiate(wasp, new Vector3(pos, 6, 0), new Quaternion(0, 0, 0, 0));

            waspController bug = newbug.GetComponent<waspController>();
            SpriteRenderer sprite = newbug.GetComponent<SpriteRenderer>();
            bug.dir = Vector3.down;

            if(flip > .5f)
            {
                sprite.flipX = true;
            }
        }

        if (dir <= .5)
        {
            float pos = Random.Range(-2.3f, 2.3f);

            float flip = Random.value;

            GameObject newbug = Instantiate(wasp, new Vector3(pos, -6, 0), new Quaternion(0, 0, 0, 0));

            waspController bug = newbug.GetComponent<waspController>();
            SpriteRenderer sprite = newbug.GetComponent<SpriteRenderer>();
            bug.dir = Vector3.up;

            if (flip > .5f)
            {
                sprite.flipX = true;
            }

        }
    }

    void HorWasp()
    {
        float dir = Random.value;

        if (dir > .5f)
        {
            float pos = Random.Range(-1.65f, 1.65f);

            GameObject newbug = Instantiate(wasp, new Vector3(4, pos, 0), new Quaternion(0, 0, 0, 0));

            waspController bug = newbug.GetComponent<waspController>();
            SpriteRenderer sprite = newbug.GetComponent<SpriteRenderer>();
            bug.dir = Vector3.left;
            sprite.flipX = true;
        }

        if (dir <= .5)
        {
            float pos = Random.Range(-1.65f, 1.65f);

            GameObject newbug = Instantiate(wasp, new Vector3(-4, pos, 0), new Quaternion(0, 0, 0, 0));

            waspController bug = newbug.GetComponent<waspController>();
            bug.dir = Vector3.right;
        }
    }
}
