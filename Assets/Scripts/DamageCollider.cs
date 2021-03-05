using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class DamageCollider : MonoBehaviour {
        Collider[] damageColliders;

        public int currentWeaponDamage;
        private void Awake() {
            damageColliders = GetComponentsInChildren<Collider>();
            foreach (Collider c in damageColliders) {
                c.gameObject.SetActive(true);
                c.isTrigger = true;
                c.enabled = false;
            }
        }

        public void EnableDamageCollider() {
            foreach (Collider c in damageColliders) {
                c.enabled = true;
            }
        }

        public void DisableDamageCollider() {
            foreach (Collider c in damageColliders) {
                c.enabled = false;
            }
        }

        private void OnTriggerEnter(Collider collision) {
            if (collision.tag == "Player") {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null) {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }
            if (collision.tag == "Enemy") {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
                if (enemyStats != null) {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }

    }
}