using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class PlayerAttacker : MonoBehaviour {
        AnimatorHandler animatorHandler;

        private void Awake() {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }
        public void HandleLightAttack(WeaponItem weapon) {
            animatorHandler.PlayTargetAnimation(weapon.OneHandLightAttack_1, true);
        }

        public void HandleHeavyAttack(WeaponItem weapon) {
            animatorHandler.PlayTargetAnimation(weapon.OneHandHeavyAttack_1, true);
        }
    }
}