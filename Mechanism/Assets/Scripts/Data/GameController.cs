using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<GameObject> players;
    private List<GameObject> bots;
    public string gameMode;
    // Start is called before the first frame update
    void Start()
    {
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        bots.AddRange(GameObject.FindGameObjectsWithTag("Bot"));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMode == "DEBUG") {

        }
        else if (gameMode == "Undefined") {

        }
        else if (gameMode == "Elimination") {
            if (!isAnyPlayerAlive()) {
                //End Game
            }
            if (!isAnyBotAlive()) {
                //End Game
            }
        }
        else if (gameMode == "Flag") {
            if (!isAnyPlayerAlive()) {
                //End Game
            }
            if (!isAnyBotAlive()) {
                //End Game
            }
        }
        else {
            Debug.LogError("No game mode found called " + gameMode + ". Entering generic game mode.");
            gameMode = "Undefined";
        }
    }

    public bool isPlayerAlive(GameObject player) {
        if (players.Contains(player)) return true;
        return false;
    }
    public bool isAnyPlayerAlive() {
        if (players.Count == 0) return false;
        return true;
    }
    public bool isAnyBotAlive() {
        if (bots.Count == 0) return false;
        return true;
    }
}
