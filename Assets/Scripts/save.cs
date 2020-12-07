using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour {

	public void saveHiScore()
    {
        GameMonitor.Instance.Save();
    }
}
