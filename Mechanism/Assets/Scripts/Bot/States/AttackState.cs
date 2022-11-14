using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State {
    public IdleState idleState;
    public PursuitState pursuitState;
    public bool isInAttackRange;

    public override State RunCurrentState() {
        if (!isInAttackRange) {
            return pursuitState;
        }
        return this;
    }
}
