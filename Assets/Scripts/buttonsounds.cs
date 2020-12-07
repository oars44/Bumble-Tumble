using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsounds : MonoBehaviour {

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update ()
    {
        source.volume = GameMonitor.Instance.volume;
	}
}
