using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setVol : MonoBehaviour {

    Slider slide;

    private void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = GameMonitor.Instance.volume;
    }

    private void Update()
    {

        GameMonitor.Instance.volume = slide.value;
    }

}
