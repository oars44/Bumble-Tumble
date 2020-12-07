using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
        text.text = "Your Score: " + GameMonitor.Instance.score.ToString();
	}
}
