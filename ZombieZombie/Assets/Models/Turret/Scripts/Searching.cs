using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searching : FSM_Turret
{
    private float counter = 0;
    private Vector3 _direction;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("rotate", false);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        RandomRotate();
    }

    //Поворот головы туррели в случайном направлении
    void RandomRotate()
    {
        if (counter <= 300)
        {
            _direction = Random.onUnitSphere * 10f;
            _direction.y = Mathf.Abs(_direction.y);
        }
        else
        {
            var _headRotation = Quaternion.LookRotation(_direction);
            var _turretPoration = Quaternion.LookRotation(new Vector3(0, 0, _direction.z));
            _turret.head.rotation = Quaternion.Slerp(_turret.head.rotation, _headRotation, _turret.headRotationSpeed * Time.deltaTime);
        }
        counter++;
        if (counter >= 600) counter = 0;
    }
} 
