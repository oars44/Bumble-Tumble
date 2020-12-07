using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoneyController : MonoBehaviour {

    public float value;
    public Vector3 dir;
    public GameObject plus10;
    public GameObject combo;
    public GameObject bounce;
    Camera cam;

    private GameObject text;

	void Start ()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	void Update ()
    {

        transform.Rotate(Vector3.back * 1);
        transform.position = Vector2.Lerp(transform.position, transform.position + dir, .025f);

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bee")
        {
            BeeFling fling = collision.GetComponent<BeeFling>();
            GameObject canvas = GameObject.Find("Canvas");
            Vector3 screenspace = cam.WorldToScreenPoint(transform.position);


            fling.combo += 1;

            if (!fling.OnTether)
            {

                GameMonitor.Instance.score += value;
                text = Instantiate(plus10, screenspace, Quaternion.Euler(0, 0, 0));
                text.transform.SetParent(canvas.transform, true);

                if (fling.combo >= 2)
                {
                    GameMonitor.Instance.score += 10;
                    text = Instantiate(combo, screenspace + Vector3.down, Quaternion.Euler(0,0,0));
                    text.transform.SetParent(canvas.transform, true);
                }

                if (fling.lastTouched == "RightBumper" || fling.lastTouched == "LeftBumper")
                {
                    GameMonitor.Instance.score += 10;
                    text = Instantiate(bounce, screenspace + (Vector3.down * 2), Quaternion.Euler(0, 0, 0));
                    text.transform.SetParent(canvas.transform, true);
                }

                Destroy(gameObject);
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
