using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class DestroyableHPManager : HPManager
    {
        [SerializeField] GameObject drop;

        public override void OnDeath()
        {
            if (drop != null)
                Instantiate(drop, transform.position, Quaternion.identity);

            OneTimePickup OTPickup = GetComponent<OneTimePickup>();

            if (OTPickup != null)
            {
                OTPickup.PickedUp();
            }

            Destroy(gameObject);
        }
    }
}