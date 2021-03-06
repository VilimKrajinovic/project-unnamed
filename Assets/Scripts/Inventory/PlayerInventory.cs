using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class PlayerInventory : MonoBehaviour {
        WeaponSlotManager weaponSlotManager;
        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;
        public WeaponItem unarmedWeapon;

        public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[1];
        public WeaponItem[] weaponsInLeftHandSlots = new WeaponItem[1];
        public int currentRightWeaponIndex = -1;
        public int currentLeftWeaponIndex = -1;
        private void Awake() {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start() {
            rightWeapon = unarmedWeapon;
            leftWeapon = unarmedWeapon;
        }

        public void ChangeRightWeapon() {
            currentRightWeaponIndex++;

            if (currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] != null) {
                rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.LoadWeapnOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
            } else if (currentRightWeaponIndex == 0 && weaponsInRightHandSlots[currentRightWeaponIndex] == null) {
                currentRightWeaponIndex++;
            } else if (currentRightWeaponIndex == 1 && weaponsInRightHandSlots[1] != null) {
                rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.LoadWeapnOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
            } else if (currentRightWeaponIndex == 1 && weaponsInRightHandSlots[1] == null) {
                currentRightWeaponIndex++;
            }

            if (currentRightWeaponIndex > weaponsInRightHandSlots.Length - 1) {
                currentRightWeaponIndex = -1;
                rightWeapon = unarmedWeapon;
                weaponSlotManager.LoadWeapnOnSlot(rightWeapon, false);
            }
        }

        public void ChangeLeftWeapon() {
            currentLeftWeaponIndex++;

            if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlots[0] != null) {
                leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeapnOnSlot(weaponsInLeftHandSlots[currentLeftWeaponIndex], true);
            } else if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlots[currentLeftWeaponIndex] == null) {
                currentLeftWeaponIndex++;
            } else if (currentLeftWeaponIndex == 1 && weaponsInLeftHandSlots[1] != null) {
                leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeapnOnSlot(weaponsInLeftHandSlots[currentLeftWeaponIndex], true);
            } else if (currentLeftWeaponIndex == 1 && weaponsInLeftHandSlots[1] == null) {
                currentLeftWeaponIndex++;
            }

            if (currentLeftWeaponIndex > weaponsInLeftHandSlots.Length - 1) {
                currentLeftWeaponIndex = -1;
                leftWeapon = unarmedWeapon;
                weaponSlotManager.LoadWeapnOnSlot(leftWeapon, true);
            }
        }

    }
}