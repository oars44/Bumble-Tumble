using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperController : MonoBehaviour {

    public GameObject bee;
    public AudioClip bounce;

    private AudioSource source;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bee")
        {
            source.clip = bounce;
            source.volume = GameMonitor.Instance.volume;
            source.Play();
        }
    }

}
