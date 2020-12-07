using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVol : MonoBehaviour {

    public static MusicVol Instance;

    AudioSource source;

    private void Awake()
    {
        if(Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    void Start ()
    {
        source = GetComponent<AudioSource>();
	}
	

	void Update ()
    {
        source.volume = GameMonitor.Instance.volume;
	}
}
