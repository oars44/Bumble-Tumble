using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreController : MonoBehaviour {

    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
		if(GameMonitor.Instance.score >= GameMonitor.Instance.hiscore)
        {
            GameMonitor.Instance.hiscore = GameMonitor.Instance.score;
        }

        text.text = "High Score: " + GameMonitor.Instance.hiscore.ToString();

	}
}
