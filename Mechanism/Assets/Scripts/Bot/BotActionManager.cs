using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotActionManager : MonoBehaviour {
    Animator animator;
    int speed;
    int motionSpeed;

    private void Awake() {
        animator = GetComponent<Animator>();
        speed = Animator.StringToHash("Speed");
        motionSpeed = Animator.StringToHash("MotionSpeed");
    }

    public void HandleMovement(float currentSpeed) {
        if (currentSpeed <= 0.5f) {
            animator.SetFloat(speed, 0, 0.1f, Time.deltaTime);
            //animator.SetFloat(motionSpeed, 0, 10.0f, Time.deltaTime);
        }
        else {
            animator.SetFloat(speed, currentSpeed * 2.1f, 0.1f, Time.deltaTime);
            animator.SetFloat(motionSpeed, currentSpeed * 0.03f, 0.1f, Time.deltaTime);
        }
    }
}
