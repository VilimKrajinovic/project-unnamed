using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour {
    private Animator animator;
    private CharacterController controller;
    private int speedHash;
    void Start() {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void FixedUpdate() {
        animator.SetFloat("Speed", controller.velocity.magnitude);
        if (!controller.isGrounded) {
            animator.SetBool("Jumping", true);
        } else {
            animator.SetBool("Jumping", false);
        }
    }
}