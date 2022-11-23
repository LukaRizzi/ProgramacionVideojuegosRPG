using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class EnemyHPManager : HPManager
    {
        [SerializeField] private GameObject[] drops;
        [Range(0, 1)]
        [SerializeField] private float chance = 1;

        public override void OnDeath()
        {
            if (drops.Length > 0 && Random.Range(0, 1f) <= chance)
            {
                GameObject drop = Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
                OneTimePickup otp = drop.GetComponent<OneTimePickup>();
                if (otp != null)
                    Destroy(otp);
            }

            Destroy(this.gameObject);
        }
    }
}