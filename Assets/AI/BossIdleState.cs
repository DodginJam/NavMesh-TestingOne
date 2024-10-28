using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public override void EnterState(BossStateManager bossManager)
    {
        bossManager.Agent.SetDestination(bossManager.transform.position);
        bossManager.BossAnimator.SetTrigger("Idle");
    }

    public override void UpdateState(BossStateManager bossManager)
    {
        bossManager.PlayerTarget = GameObject.FindWithTag("Player").transform;

        if (bossManager.PlayerTarget != null)
        {
            float distanceToPlayer = (bossManager.transform.position - bossManager.PlayerTarget.position).magnitude;

            if (distanceToPlayer < bossManager.DistanceToDetect)
            {
                bossManager.SwitchState(bossManager.ChaseState);
            }
        }
    }

    public override void UpdateStateFixed(BossStateManager bossManager)
    {

    }

    public override void ExitState(BossStateManager bossManager)
    {

    }
}
