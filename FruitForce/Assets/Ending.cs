using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    private int limit = 180;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if(counter>limit)
        {
            Application.Quit();
        }
    }
}
