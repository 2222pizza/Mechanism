using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {
    public bool canSeePlayer;
    public PursuitState pursuitState;

    public override State RunCurrentState() {
        if(canSeePlayer) {
            return pursuitState;
        }
        return this;
    }
}

