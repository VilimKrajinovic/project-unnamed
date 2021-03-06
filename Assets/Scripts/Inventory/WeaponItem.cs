using UnityEngine;

namespace VK {
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item {

        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string rightHandIdleKatana;
        public string leftHandIdleKatana;

        [Header("One Handed Attack Animations")]
        public string oneHandLightAttack_1;
        public string oneHandLightAttack_2;
        public string oneHandHeavyAttack_1;

    }
}