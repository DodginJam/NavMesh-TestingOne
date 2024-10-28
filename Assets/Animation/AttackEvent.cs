using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public BossStateManager BossStateManagerScript
    { get; private set; }
    public DealDamage WeaponDealDamageScript
    { get; private set; }

    private void Awake()
    {
        BossStateManagerScript = GameObject.FindAnyObjectByType<BossStateManager>();
        WeaponDealDamageScript = GetComponentInChildren<DealDamage>();
    }

    public void AllowTriggerOnWeapon(string trueOrFalse)
    {
        bool isAllowed;
        bool parseSuccess = Boolean.TryParse(trueOrFalse, out isAllowed);

        if (parseSuccess)
        {
            WeaponDealDamageScript.SetWeaponTrigger(isAllowed);
            Debug.Log($"Weapon trigger set to: {isAllowed}");
        }
        else
        {
            Debug.LogError("Non-boolean passed to an attack event script.");
        }
    }

}
