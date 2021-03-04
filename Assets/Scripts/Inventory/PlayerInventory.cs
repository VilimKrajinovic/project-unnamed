using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    WeaponSlotManager weaponSlotManager;
    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;

    private void Awake() {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start() {
        weaponSlotManager.LoadWeapnOnSlot(rightWeapon, false);
        weaponSlotManager.LoadWeapnOnSlot(leftWeapon, true);
    }
}