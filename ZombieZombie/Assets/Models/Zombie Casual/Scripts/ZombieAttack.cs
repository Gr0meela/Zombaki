using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : FSM_Zombie
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("run", false);
        animator.SetBool("idle", false);
        animator.SetBool("scream", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        //if (_currentTarget == null) animator.SetBool("idle", true);
    }
    
}
