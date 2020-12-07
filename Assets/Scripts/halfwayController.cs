using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfwayController : MonoBehaviour {

    public GameObject bee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bee")
        {
            Debug.Log("Bee found");

            BeeFling fling = bee.GetComponent<BeeFling>();

            fling.ignore = false;
        }
    }
}
