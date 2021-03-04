using UnityEngine;

namespace VK {
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item {

        public GameObject modelPrefab;
        public bool isUnarmed;

    }
}