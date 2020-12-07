using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBee : MonoBehaviour {

    IEnumerator corutine;

	void Update ()
    {
        transform.Rotate(Vector3.back * 1);
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down, .025f);

        corutine = die();
        StartCoroutine(corutine);
	}

    IEnumerator die()
    {
        yield return new WaitForSecondsRealtime(15f);
        Destroy(gameObject);
    }
}
