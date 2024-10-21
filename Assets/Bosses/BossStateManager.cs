using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    static public BossStateManager BossStateManagerSingleton
    { get; private set; }

    public BossBaseState CurrentState
    { get; private set; }
    public BossIdleState IdleState
    { get; private set; } = new BossIdleState();
    public BossChaseState ChaseState
    { get; private set; } = new BossChaseState();
    public BossAttackState AttackState
    { get; private set; } = new BossAttackState();

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
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = IdleState;

        CurrentState.EnterState(this);

        Debug.Log("Entered Idles State");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
