using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour {

    public void ResetScore()
    {
        GameMonitor.Instance.score = 0f;
    }

}
