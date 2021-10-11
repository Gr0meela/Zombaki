using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM_Zombie : StateMachineBehaviour
{
    protected Zombie _zombie;
    protected GameObject NPC;
    protected GameObject _currentTarget;
    protected Transform _currentPos;
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        _zombie = NPC.GetComponent<Zombie>();
        _currentTarget = _zombie.attackIt;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            _currentTarget = _zombie.attackIt;
            animator.SetFloat("distance", Vector3.Distance(_zombie.transform.position, _currentTarget.transform.position));
        }
        catch { }
    }
}
