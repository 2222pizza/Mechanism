using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool victory = false;
    public List<GameObject> players;
    public List<GameObject> bots;
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
                SceneManager.LoadScene(sceneName: "End Scene");
                Cursor.lockState = false ? CursorLockMode.Locked : CursorLockMode.None;
                victory = false;
                //GameObject.FindGameObjectWithTag("Finish").transform.GetChild(0).gameObject.SetActive(false);
                //GameObject.FindGameObjectWithTag("Finish").transform.GetChild(1).gameObject.SetActive(true);
            }
            if (!isAnyBotAlive()) {
                SceneManager.LoadScene(sceneName: "End Scene");
                Cursor.lockState = false ? CursorLockMode.Locked : CursorLockMode.None;
                victory = true;
                //GameObject.FindGameObjectWithTag("Finish").transform.GetChild(0).gameObject.SetActive(true);
                //GameObject.FindGameObjectWithTag("Finish").transform.GetChild(1).gameObject.SetActive(false);
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

    private bool isPlayerAlive(GameObject player) {
        if (players.Contains(player)) return true;
        return false;
    }
    private bool isAnyPlayerAlive() {
        if (players.Count == 0) return false;
        return true;
    }
    private bool isAnyBotAlive() {
        if (bots.Count == 0) return false;
        return true;
    }
}
