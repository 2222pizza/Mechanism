using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : HealthManager {
    public override void OnNoHealth() {
        Debug.Log("Player is dead.");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().players.Remove(gameObject);
        //Do dead player things
        Destroy(gameObject);
    }
}
