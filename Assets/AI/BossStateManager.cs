using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The manager of the bosses states. Contains references to all state classes, and set's one active at any given time. All state logic is called in here via polymorphic methods.
/// </summary>
public class BossStateManager : MonoBehaviour
{
    // Singleton methods ensures only one BossStateManager runs at any given time.
    static public BossStateManager BossStateManagerSingleton
    { get; private set; }

    // Active state that the boss is in, determining its behaviour as defined in the respective state classes.
    public BossBaseState CurrentState
    { get; private set; }

    // Boss States Variable holding reference to respective available states.
    public BossIdleState IdleState
    { get; private set; } = new BossIdleState();
    public BossChaseState ChaseState
    { get; private set; } = new BossChaseState();
    public BossAttackState AttackState
    { get; private set; } = new BossAttackState();

    // Variables for reference within multiple different states.
    public NavMeshAgent Agent
    { get; private set; }
    public Transform PlayerTarget
    { get; set; }
    public Animator BossAnimator
    { get; private set; }
    public float DistanceToDetect
    { get; private set; } = 45.0f;
    public float DistanceForAttack
    { get; private set; } = 5.0f;
    public float AttackDamage
    { get; private set; } = 20.0f;

    // Debugging variables.
    [field: SerializeField] public string CurrentStateDisplay
    { get; private set; }
    [field: SerializeField]
    public float DistanceToTarget { get; private set; }

    private void Awake()
    {
        // Singleton methods ensures only one BossStateManager runs at any given time.
        if (BossStateManagerSingleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            BossStateManagerSingleton = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // Retreving references to components.
        Agent = GetComponent<NavMeshAgent>();
        BossAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        CurrentState = IdleState;
    }

    void Update()
    {
        CurrentState.UpdateState(this);

        // Deugging Information updated
        CurrentStateDisplay = CurrentState.ToString();
        DistanceToTarget = (transform.position - PlayerTarget.position).magnitude;
    }

    private void FixedUpdate()
    {
        CurrentState.UpdateStateFixed(this);
    }

    public void SwitchState(BossBaseState newState)
    {
        CurrentState.ExitState(this);
        CurrentState = newState;
        CurrentState.EnterState(this);
    }
}
