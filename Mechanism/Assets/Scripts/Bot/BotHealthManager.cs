using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHealthManager : HealthManager {
    public override void OnNoHealth() {
        Debug.Log("Bot is dead.");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().bots.Remove(gameObject);
        Destroy(gameObject);
    }
}
