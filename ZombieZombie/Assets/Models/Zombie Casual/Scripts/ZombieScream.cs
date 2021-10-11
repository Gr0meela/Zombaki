using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScream : FSM_Zombie
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("run", false);
        animator.SetBool("idle", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            animator.SetBool("idle", true);
    }
}
