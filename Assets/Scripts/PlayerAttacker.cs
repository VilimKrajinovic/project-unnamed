using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class PlayerAttacker : MonoBehaviour {
        AnimatorHandler animatorHandler;
        InputHandler inputHandler;
        public string lastAttack;

        private void Awake() {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            inputHandler = GetComponent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem weapon) {
            if (inputHandler.comboFlag) {
                animatorHandler.animator.SetBool("canDoCombo", false);
                if (lastAttack == weapon.oneHandLightAttack_1) {
                    animatorHandler.PlayTargetAnimation(weapon.oneHandLightAttack_2, true);
                }
            }
        }

        public void HandleLightAttack(WeaponItem weapon) {
            animatorHandler.PlayTargetAnimation(weapon.oneHandLightAttack_1, true);
            lastAttack = weapon.oneHandLightAttack_1;
        }

        public void HandleHeavyAttack(WeaponItem weapon) {
            animatorHandler.PlayTargetAnimation(weapon.oneHandHeavyAttack_1, true);
            lastAttack = weapon.oneHandHeavyAttack_1;
        }
    }
}