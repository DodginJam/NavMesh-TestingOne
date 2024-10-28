using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public override void EnterState(BossStateManager bossManager)
    {
        bossManager.BossAnimator.SetTrigger("Attack");
        bossManager.Agent.SetDestination(bossManager.transform.position - ((bossManager.transform.position - bossManager.PlayerTarget.position) / 2).normalized);
    }

    public override void UpdateState(BossStateManager bossManager)
    {
        if (bossManager.PlayerTarget == null)
        {
            bossManager.SwitchState(bossManager.IdleState);
            return;
        }

        Vector3 distanceToPlayer = bossManager.PlayerTarget.position - bossManager.transform.position;
        float lengthToPlayer = (distanceToPlayer).magnitude;

        if (lengthToPlayer <= bossManager.DistanceForAttack)
        {
            bossManager.transform.rotation = RotateToTarget(bossManager.transform, distanceToPlayer, 5.0f);
        }
        else
        {
            bossManager.SwitchState(bossManager.ChaseState);
        }
    }
    public override void UpdateStateFixed(BossStateManager bossManager)
    {

    }

    public override void ExitState(BossStateManager bossManager)
    {

    }

    Quaternion RotateToTarget(Transform transformToRotate, Vector3 distanceVectorToTarget, float rotateSpeed)
    {

        return Quaternion.Slerp(transformToRotate.transform.rotation, Quaternion.LookRotation(new Vector3(distanceVectorToTarget.x, 0, distanceVectorToTarget.z).normalized), rotateSpeed * Time.deltaTime);
    }
}
