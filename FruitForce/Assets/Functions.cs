using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color CombineColors(Color c1, Color c2)
    {
        float h1, s1, v1;
        Color.RGBToHSV(c1, out h1, out s1, out v1);

        float h2, s2, v2;
        Color.RGBToHSV(c2, out h2, out s2, out v2);

        Debug.Log("color " + h1 + " " + s1 + " " + v1);
        Debug.Log("color " + h2 + " " + s2 + " " + v2);
        float difference = Mathf.Abs(h1 - h2);

        bool upside = false;
        if (difference > 0.5f)
        {
            difference = 1 - difference;
            upside = true;
        }
        difference = difference / 2;
        if (upside)
        {
            if (h1 > h2)
            {
                difference = h1 + difference;
            }
            else
            {
                difference = h2 + difference;
            }
            if (difference > 1)
            {
                difference = difference - 1;
            }
        }
        else
        {
            if (h1 < h2)
            {
                difference = h1 + difference;
            }
            else
            {
                difference = h2 + difference;
            }
        }

        float h = difference;
        float s = (s1 + s2) / 2;
        float v = (v1 + v2) / 2;
        return Color.HSVToRGB(h, s, v);
    }
}
