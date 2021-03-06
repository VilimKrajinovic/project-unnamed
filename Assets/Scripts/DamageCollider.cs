using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VK {
    public class DamageCollider : MonoBehaviour {
        Collider[] damageColliders;
        bool alreadyHit = false;

        public int currentWeaponDamage = 25;
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
            alreadyHit = false;
        }

        private void OnTriggerExit(Collider collision) {
            alreadyHit = false;
        }
        private void OnTriggerEnter(Collider collision) {
            if (alreadyHit) return;
            alreadyHit = true;
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