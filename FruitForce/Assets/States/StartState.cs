using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : StateMachineBehaviour
{
    private GameObject _state = null;
  
    public override void OnStateEnter(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        _state = animator.GetComponentInChildren<StateEngine>().StartState;

        // enable startmenu canvas
        _state.gameObject.SetActive(true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        // disable startmenu canvas
        _state.SetActive(false);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo info, int layerIndex)
    {

    }
}
