using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BossStateManager : MonoBehaviour
{
    static public BossStateManager BossStateManagerSingleton
    { get; private set; }

    private BossBaseState CurrentState
    { get; set; }
    public BossIdleState IdleState
    { get; private set; } = new BossIdleState();
    public BossChaseState ChaseState
    { get; private set; } = new BossChaseState();
    public BossAttackState AttackState
    { get; private set; } = new BossAttackState();

    public NavMeshAgent Agent
    { get; private set; }
    public Transform PlayerTarget
    { get; set; }
    public float DistanceToPlayerForAttack
    { get; private set; } = 2f;

    private void Awake()
    {
        if (BossStateManagerSingleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            BossStateManagerSingleton = this;
            DontDestroyOnLoad(this.gameObject);
        }

        Agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(BossBaseState newState)
    {
        CurrentState = newState;
        CurrentState.EnterState(this);
    }
}
