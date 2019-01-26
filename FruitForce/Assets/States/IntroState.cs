using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState : StateMachineBehaviour {

    private GameObject _state = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        _state = animator.GetComponentInChildren<StateEngine>().IntroState;

        // enable intro canvas
        _state.gameObject.SetActive(true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        // disable intro canvas
        _state.SetActive(false);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        
    }
}
