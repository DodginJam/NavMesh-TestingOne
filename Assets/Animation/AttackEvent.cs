using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public delegate void MethodToCall(float a);
    public event MethodToCall OnAnimationEvent;

    public BossStateManager BossStateManagerScript
    { get; private set; }
    public float AttackDamage
    { get; private set; }
    public Animation AnimationPlayer
    { get; private set; }

    private void Awake()
    {
        BossStateManagerScript = GameObject.FindAnyObjectByType<BossStateManager>();
    }

    void Start()
    {
        OnAnimationEvent += HandleAnimationEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleAnimationEvent(float attackDamageModifier)
    {
        AnimationPlayer.Play("Swing_Top");
    }
}
