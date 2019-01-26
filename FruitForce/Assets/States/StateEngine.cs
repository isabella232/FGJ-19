﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEngine : MonoBehaviour
{
    public GameObject StartState
    {
        get { return transform.Find("StartState").gameObject; }
    }

    public GameObject IntroState
    {
        get { return transform.Find("IntroState").gameObject; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}