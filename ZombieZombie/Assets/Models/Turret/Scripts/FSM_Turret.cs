using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Turret : StateMachineBehaviour
{
    protected Turret _turret;
    protected GameObject NPC;
    protected GameObject _currentTarget;
    protected Transform _currentPos;
    protected float angle;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        _turret = NPC.GetComponent<Turret>();
        _currentTarget = _turret.attackIt;
        angle = Mathf.Clamp(angle, -60, 30);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            _currentTarget = _turret.attackIt;
        }
        catch { }
    }
}
