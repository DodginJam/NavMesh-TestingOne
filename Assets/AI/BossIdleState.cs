using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public override void EnterState(BossStateManager bossManager)
    {

    }

    public override void UpdateState(BossStateManager bossManager)
    {
        bossManager.PlayerTarget = GameObject.FindWithTag("Player").transform;

        if (bossManager.PlayerTarget != null)
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
}
