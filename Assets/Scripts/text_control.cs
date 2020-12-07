using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_control : MonoBehaviour
{
    Vector2 dir;
    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        dir = new Vector2(0, 0);
    }

    
    void Update()
    {
        rt.anchoredPosition = Vector2.Lerp(transform.position, rt.anchoredPosition + dir, .00001f);
    }
}
