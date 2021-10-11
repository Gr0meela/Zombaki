using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdle : FSM_Zombie
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("run", false);
        animator.SetBool("scream", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (Random.Range(1, 1000) == 666) 
            animator.SetBool("scream", true);
    }
}
