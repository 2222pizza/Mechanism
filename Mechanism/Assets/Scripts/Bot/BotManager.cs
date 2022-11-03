using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotManager : MonoBehaviour {
    private Transform target;
    private NavMeshAgent agent;
    BotActionManager botActionManager;
    private string currentState;


    Animator animator;
    int horizontal;
    int vertical;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        botActionManager = GetComponent<BotActionManager>();
        currentState = "Idle";


        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    void Update() {
        target = GameObject.FindWithTag("Player").transform;
        agent.destination = target.position;
    }

    private void FixedUpdate() {
        if (currentState == "Idle") {
            target = transform;
            if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) > 20) {
                currentState = "Pursuit";
            }
        }
        if (currentState == "Pursuit") {
            target = GameObject.FindWithTag("Player").transform;
            if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= 20) {
                currentState = "Idle";
            }
        }
        agent.destination = target.position;
        botActionManager.HandleMovement(agent.velocity.magnitude);
    }

    private void LateUpdate() {

    }


}
