using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The absract state that all states that the boss have inherit from here.
/// </summary>
public abstract class BossBaseState
{
    /// <summary>
    /// Method called when a state is entered. Accessed by current instance of State via BossStateManager. 
    /// Can be used to initalise any outstanding data / variables required for state.
    /// </summary>
    public abstract void EnterState(BossStateManager bossManager);
    /// <summary>
    /// Method called every frame a state is currently accessed. Accessed by current instance of State via BossStateManager.
    /// </summary>
    public abstract void UpdateState(BossStateManager bossManager);
    /// <summary>
    /// Method called every physics update a state is currently accessed. Accessed by current instance of State via BossStateManager.
    /// </summary>
    public abstract void UpdateStateFixed(BossStateManager bossManager);
    /// <summary>
    /// Method called when a state is exited. Accessed by current instance of State via BossStateManager.
    /// Used to clear/reset or restore any outstanding data / variables.
    /// </summary>
    public abstract void ExitState(BossStateManager bossManager);
}
