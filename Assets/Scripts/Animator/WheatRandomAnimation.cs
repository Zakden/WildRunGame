using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatRandomAnimation : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Wind_02");
        animator.ResetTrigger("Wind_03");
        int rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                animator.ResetTrigger("Wind_02");
                animator.ResetTrigger("Wind_03");
                break;
            case 2:
                animator.SetTrigger("Wind_02");
                break;
            case 3:
                animator.SetTrigger("Wind_03");
                break;
        }
    }
}
