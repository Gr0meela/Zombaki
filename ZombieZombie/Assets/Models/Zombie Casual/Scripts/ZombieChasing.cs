using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChasing : FSM_Zombie
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("idle", false);
        animator.SetBool("scream", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        try
        {
            _zombie.meshAgent.SetDestination(_currentTarget.transform.position);
        }
        catch { }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _zombie.meshAgent.SetDestination(_zombie.transform.position);
    }
}
