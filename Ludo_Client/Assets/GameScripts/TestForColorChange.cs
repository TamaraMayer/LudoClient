using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForColorChange : MonoBehaviour
{
    public static Color test
    {
        get
        {
            return _test;
        }
        set
        {
            _test = value;
            rend.material.color = value;
        }
    }

    Color colorStart = Color.red;
    Color colorEnd = Color.green;
    //float duration = 1.0f;
    public static Renderer rend;
    private static Color _test;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //  rend.material.color = test;
    }

    // Update is called once per frame
    void Update()
    {
        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
}
