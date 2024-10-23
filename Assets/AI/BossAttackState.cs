using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public float AttackTimerConstant
    { get; private set; } = 1f;
    public float AttackCountDownTimer
    { get; private set; } = 0.0f;
    public Rigidbody Weapon
    { get; private set; }
    public Vector3 WeaponPositionDefault
    { get; private set; }
    public Quaternion WeaponRotationDefault
    { get; private set; }

    public override void EnterState(BossStateManager bossManager)
    {
        if (Weapon == null)
        {
            Weapon = bossManager.transform.Find("Weapon").GetComponent<Rigidbody>();
            WeaponPositionDefault = Weapon.transform.position;
            WeaponRotationDefault = Weapon.transform.rotation;
        }
    }

    public override void UpdateState(BossStateManager bossManager)
    {
        if (bossManager.PlayerTarget == null)
        {
            bossManager.SwitchState(bossManager.IdleState);
            return;
        }

        AttackCountDownTimer -= Time.deltaTime;

        Vector3 distanceToPlayer =  bossManager.PlayerTarget.position - bossManager.transform.position;
        float lengthToPlayer = (distanceToPlayer).magnitude;

        if (lengthToPlayer <= bossManager.DistanceToPlayerForAttack)
        {
            bossManager.transform.rotation = RotateToTarget(bossManager.transform, distanceToPlayer, 5.0f);

            if (AttackCountDownTimer <= 0)
            {
                // Shoudl switch to a new attack recovery state instead.
                AttackPlayer(bossManager);
            }
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

    void AttackPlayer(BossStateManager bossManager)
    {
        Rigidbody weaponRigidBody = Weapon;

        // Either attack with a torque effect for a phyics based hit, starting be turning off kinematic then turning it on again once
        //weaponRigidBody.AddTorque();

        Debug.Log("Damage Dealt to Player");
        AttackCountDownTimer = AttackTimerConstant;
    }

    Quaternion RotateToTarget(Transform transformToRotate, Vector3 distanceVectorToTarget, float rotateSpeed)
    {

        return Quaternion.Slerp(transformToRotate.transform.rotation, Quaternion.LookRotation(new Vector3(distanceVectorToTarget.x, 0, distanceVectorToTarget.z).normalized), rotateSpeed * Time.deltaTime);
    }
}
