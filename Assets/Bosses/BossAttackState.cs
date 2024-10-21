using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public float AttackTimerConstant
    { get; private set; } = 1f;
    public float AttackCountDownTimer
    { get; private set; } = 0.0f;

    public override void EnterState(BossStateManager bossManager)
    {

    }

    public override void UpdateState(BossStateManager bossManager)
    {
        if (bossManager.PlayerTarget == null)
        {
            bossManager.SwitchState(bossManager.IdleState);
            return;
        }

        AttackCountDownTimer -= Time.deltaTime;

        Vector3 distanceToPlayer = bossManager.transform.position - bossManager.PlayerTarget.position;
        float lengthToPlayer = (distanceToPlayer).magnitude;

        if (lengthToPlayer <= bossManager.DistanceToPlayerForAttack)
        {
            bossManager.Agent.SetDestination(bossManager.transform.position);
            // bossManager.transform.rotation = Vector3.Slerp();

            if (AttackCountDownTimer <= 0)
            {
                AttackPlayer();
            }
        }
        else
        {
            bossManager.SwitchState(bossManager.ChaseState);
        }
    }

    public override void ExitState(BossStateManager bossManager)
    {

    }

    void AttackPlayer()
    {
        Debug.Log("Damage Dealt to Player");
        AttackCountDownTimer = AttackTimerConstant;
    }
}
