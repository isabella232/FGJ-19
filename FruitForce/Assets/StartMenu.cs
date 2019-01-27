using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private Animator _state_controller;

    // Start is called before the first frame update
    void Start()
    {
        _state_controller = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("c0_button_x"))
        {
            _state_controller.SetTrigger("Game");
        }
    }
}
