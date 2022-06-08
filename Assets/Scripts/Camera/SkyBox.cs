using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public float colorChangeSpeed = 0.36f;
    private float h;
    public float s;
    public float v;


    private void Update()
    {
        h += colorChangeSpeed * Time.deltaTime;
        if (h >= 1)
            h = 0;
        Camera.main.backgroundColor = Color.HSVToRGB(h, s, v);

        Mathf.Clamp(h, 0, 1);
        Mathf.Clamp(s, 0, 1);
        Mathf.Clamp(v, 0, 1);
    }
}
