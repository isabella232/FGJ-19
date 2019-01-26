using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : StateMachineBehaviour
{
    public bool button = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo info, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        Debug.Log("jooh");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        
    }
}
