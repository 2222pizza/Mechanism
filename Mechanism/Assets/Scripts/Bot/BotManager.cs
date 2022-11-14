using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotManager : MonoBehaviour {
    private Transform target;
    private Transform shootingTarget;
    private NavMeshAgent agent;
    BotActionManager botActionManager;
    private string currentState;
    private int shootFrame = 0;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

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
        shootFrame++;
        if (currentState == "Idle") {
            target = transform;
            shootingTarget = GameObject.FindWithTag("Player").transform;
            if (shootFrame == 20) {
                ShootTarget(shootingTarget);
                shootFrame = 0;
            }
            if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) > 50) {
                currentState = "Pursuit";
                shootFrame = 0;
            }
        }
        if (currentState == "Pursuit") {
            target = GameObject.FindWithTag("Player").transform;
            if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= 50) {
                currentState = "Idle";
                shootFrame = 0;
            }
            shootingTarget = GameObject.FindWithTag("Player").transform;
            if (shootFrame == 30) {
                ShootTarget(shootingTarget);
                shootFrame = 0;
            }
        }
        agent.destination = target.position;
        botActionManager.HandleMovement(agent.velocity.magnitude);
    }

    private void LateUpdate() {

    }

    private void ShootTarget(Transform targetToShoot) {
        Vector3 aimDir = (targetToShoot.position + new Vector3(0.0f, 7.0f, 0.0f) + new Vector3(UnityEngine.Random.Range(-2.0f, 2.0f), UnityEngine.Random.Range(-2.0f, 2.0f), UnityEngine.Random.Range(-2.0f, 2.0f)) - spawnBulletPosition.position).normalized;
        Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up)); 
    }
}
