using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waspController : MonoBehaviour {

    public Vector3 dir;
    public AudioClip die;

    private AudioSource source;

	void Start ()
    {
        source = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + dir, .025f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bee")
        {
            BeeFling fling = collision.GetComponent<BeeFling>();

            if (!fling.OnTether)
            {
                source.clip = die;
                source.volume = GameMonitor.Instance.volume;
                source.Play();

                fling.Die();
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "deleteBox")
        {
            Destroy(gameObject);
        }
    }
}
