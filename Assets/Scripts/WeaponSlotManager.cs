using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class WeaponSlotManager : MonoBehaviour {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider righHandtDamageCollider;

        private void Awake() {
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
            } else {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
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