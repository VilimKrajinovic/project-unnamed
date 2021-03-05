using UnityEngine;

namespace VK {
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item {

        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("One Handed Attack Animations")]
        public string OneHandLightAttack_1;
        public string OneHandHeavyAttack_1;

    }
}