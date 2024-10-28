using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public BossStateManager BossStateManagerScript
    { get; private set; }

    private void Awake()
    {
        BossStateManagerScript = GameObject.FindAnyObjectByType<BossStateManager>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
