using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class PlayerManager : MonoBehaviour {
        InputHandler inputHandler;
        Animator animator;
        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;

        public bool isInteracting;

        [Header("Player flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;
        public bool canDoCombo;

        private void Awake() {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        private void Start() {
            inputHandler = GetComponent<InputHandler>();
            animator = GetComponentInChildren<Animator>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }
        void Update() {
            float delta = Time.deltaTime;

            isInteracting = animator.GetBool("isInteracting");
            canDoCombo = animator.GetBool("canDoCombo");

            inputHandler.TickInput(delta);
            playerLocomotion.HandleMovement(delta);
            playerLocomotion.HandleRollingAndSprinting(delta);
            playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        }

        private void FixedUpdate() {
            float delta = Time.deltaTime;
            if (cameraHandler != null) {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }

        private void LateUpdate() {
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
            inputHandler.lightAttackInput = false;
            inputHandler.heavyAttackInput = false;
            inputHandler.leftQuickSlotInput = false;
            inputHandler.rightQuickSlotInput = false;
            if (isInAir) {
                playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
            }
        }
    }
}