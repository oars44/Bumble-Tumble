using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovment : MonoBehaviour {

    public GameObject[] clouds = new GameObject[11];
    float speed;

    private void Update()
    {
        
        for(int n = 1; n <= 10; n++)
        {
            Vector3 dest = clouds[n].transform.position + Vector3.right;

            if (n == 2 || n == 3)
                speed = 3;
            else if (n == 4 || n == 5)
                speed = 5;
            else if (n == 6 || n == 7)
                speed = 7;
            else
                speed = n;

            clouds[n].transform.position = Vector3.Lerp(clouds[n].transform.position, dest, Time.deltaTime * (speed / 6));

            
            if(clouds[n].transform.position.x > 11.5f)
            {
                clouds[n].transform.position = new Vector3(-13f, clouds[n].transform.position.y, 0);
            } 
        }

    }

}
