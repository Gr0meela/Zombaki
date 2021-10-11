using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : FSM_Turret
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("search", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        FollowTarget();
    }
    void FollowTarget()
    {
        var _direction = (_turret.attackIt.transform.position - _turret.head.position).normalized;
        var _headRotation = Quaternion.LookRotation(_direction);
        var _turretPoration = Quaternion.LookRotation(new Vector3(0, 0, _direction.z));

        _turret.head.rotation = Quaternion.Slerp(_turret.head.rotation, _headRotation, _turret.headRotationSpeed * Time.deltaTime);
        _turret.turret.rotation = Quaternion.Slerp(_turret.turret.rotation, _turretPoration, _turret.turretRotationSpeed * Time.deltaTime);
    }
}
