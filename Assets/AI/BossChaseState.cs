using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : BossBaseState
{
    public override void EnterState(BossStateManager bossManager)
    {
        bossManager.BossAnimator.SetTrigger("Chase");
    }

    public override void UpdateState(BossStateManager bossManager)
    {
        if (bossManager.PlayerTarget == null)
        {
            bossManager.SwitchState(bossManager.IdleState);
            return;
        }

        float distanceToPlayer = (bossManager.transform.position - bossManager.PlayerTarget.position).magnitude;

        if (distanceToPlayer >= bossManager.DistanceToDetect)
        {
            bossManager.SwitchState(bossManager.IdleState);
            return;
        }

        if (distanceToPlayer > bossManager.DistanceForAttack)
        {
            bossManager.Agent.SetDestination(bossManager.PlayerTarget.position);
        }
        else
        {
            bossManager.SwitchState(bossManager.AttackState);
        }
    }

    public override void UpdateStateFixed(BossStateManager bossManager)
    {

    }

    public override void ExitState(BossStateManager bossManager)
    {

    }
}
