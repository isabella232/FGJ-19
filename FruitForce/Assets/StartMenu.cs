using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private Animator _state_controller;
    public int controller = 0;

    // Start is called before the first frame update
    void Start()
    {
        _state_controller = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 1; i < 5; i++)
        {
            if (Input.GetButtonDown("c" + i + "_button_x"))
            {
                _state_controller.SetTrigger("Game");
                controller = i;
                break;
            }
        }
    }
}
