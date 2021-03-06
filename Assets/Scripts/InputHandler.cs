using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VK {

    public class InputHandler : MonoBehaviour {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_Input;
        public bool lightAttackInput;
        public bool heavyAttackInput;
        public bool rightQuickSlotInput;
        public bool leftQuickSlotInput;

        public bool comboFlag;
        public bool rollFlag;
        public bool sprintFlag;
        public float rollInputTimer;

        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerInventory playerInventory;
        PlayerManager playerManager;

        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake() {
            playerAttacker = GetComponent<PlayerAttacker>();
            playerInventory = GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
        }
        public void TickInput(float delta) {
            MoveInput(delta);
            HandleRollInput(delta);
            HandleAttackInput(delta);
            HandleQuickSlotInput();
        }
        private void MoveInput(float delta) {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollInput(float delta) {
            b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if (b_Input) {
                rollInputTimer += delta;
                sprintFlag = true;
            } else {
                if (rollInputTimer > 0 && rollInputTimer < 0.5f) {
                    sprintFlag = false;
                    rollFlag = true;
                }

                rollInputTimer = 0;
            }
        }

        private void HandleAttackInput(float delta) {
            inputActions.PlayerActions.LightAttack.performed += i => lightAttackInput = true;
            inputActions.PlayerActions.HeavyAttack.performed += i => heavyAttackInput = true;

            if (lightAttackInput) {
                if (playerManager.canDoCombo) {
                    comboFlag = true;
                    playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                } else {
                    if (playerManager.isInteracting) return;
                    if (playerManager.canDoCombo) return;
                    playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
                }
            }
            if (heavyAttackInput) {
                if (playerManager.isInteracting) return;
                if (playerManager.canDoCombo) return;
                playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
            }
        }

        private void HandleQuickSlotInput() {
            inputActions.PlayerInventory.QuickSlotRight.performed += i => rightQuickSlotInput = true;
            inputActions.PlayerInventory.QuickSlotLeft.performed += i => leftQuickSlotInput = true;
            if (rightQuickSlotInput) {
                playerInventory.ChangeRightWeapon();
            }
            if (leftQuickSlotInput) {
                playerInventory.ChangeLeftWeapon();
            }
        }

        private void OnEnable() {
            if (inputActions == null) {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            }

            inputActions.Enable();
        }

        private void OnDisable() {
            inputActions.Disable();
        }
    }
}