using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {

    private IEnumerator kill;
    Vector3 dir;

    void Start()
    {
        dir = new Vector3(0, 0, 0);
    }

    void Update ()
    {
        transform.position = Vector2.Lerp(transform.position, transform.position + dir, .025f);
        kill = destroy();
        StartCoroutine(kill);
	}

    public IEnumerator destroy()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }
}
