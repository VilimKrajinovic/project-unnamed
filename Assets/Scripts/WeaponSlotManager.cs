using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class WeaponSlotManager : MonoBehaviour {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider righHandtDamageCollider;

        Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots) {
                if (weaponSlot.isLeftHandSlot) {
                    leftHandSlot = weaponSlot;
                } else if (weaponSlot.isRightHandSlot) {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeapnOnSlot(WeaponItem weaponItem, bool isLeft) {
            if (isLeft) {
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponDamageCollider();
                #region  Handle legft weapon idle animations
                if (weaponItem != null) {
                    animator.CrossFade(weaponItem.leftHandIdleKatana, 0.2f);
                } else {
                    animator.CrossFade("Left Arm Empty", 0.2f);
                }
                #endregion
            } else {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                #region  Handle right weapon idle animations
                if (weaponItem != null) {
                    animator.CrossFade(weaponItem.rightHandIdleKatana, 0.2f);
                } else {
                    animator.CrossFade("Right Arm Empty", 0.2f);
                }
                #endregion
            }
        }

        #region Handle Weapon's Damage collider
        private void LoadLeftWeaponDamageCollider() {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRightWeaponDamageCollider() {
            righHandtDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenLefttDamageCollider() {
            leftHandDamageCollider.EnableDamageCollider();
        }
        public void OpenRightDamageCollider() {
            righHandtDamageCollider.EnableDamageCollider();
        }

        public void CloseLefttDamageCollider() {
            leftHandDamageCollider.DisableDamageCollider();
        }
        public void CloseRightDamageCollider() {
            righHandtDamageCollider.DisableDamageCollider();
        }
        #endregion

    }
}