using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotActionManager : MonoBehaviour {
    Animator animator;
    int horizontal;
    int vertical;

    private void Awake() {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void HandleMovement(float currentSpeed) {
        if (currentSpeed <= 0.2f) {
            animator.SetFloat(horizontal, 0, 0.1f, Time.deltaTime);
            animator.SetFloat(vertical, 0, 0.1f, Time.deltaTime);
        }
        else {
            animator.SetFloat(horizontal, 1, 0.1f, Time.deltaTime);
            animator.SetFloat(vertical, 1, 0.1f, Time.deltaTime);
        }
    }
}
