using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseState
{
    public abstract void EnterState(BossStateManager bossManager);

    public abstract void UpdateState(BossStateManager bossManager);

    public abstract void ExitState(BossStateManager bossManager);
}
