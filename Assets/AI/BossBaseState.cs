using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The absract state that all states that the boss have inherit from here.
/// </summary>
public abstract class BossBaseState
{
    public abstract void EnterState(BossStateManager bossManager);

    public abstract void UpdateState(BossStateManager bossManager);

    public abstract void UpdateStateFixed(BossStateManager bossManager);

    public abstract void ExitState(BossStateManager bossManager);
}
