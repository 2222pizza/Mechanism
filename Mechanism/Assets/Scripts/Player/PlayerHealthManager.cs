using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : HealthManager {
    public override void OnNoHealth() {
        Debug.Log("Player is dead.");
        //Do dead player things
        //Destroy(gameObject);
    }
}
