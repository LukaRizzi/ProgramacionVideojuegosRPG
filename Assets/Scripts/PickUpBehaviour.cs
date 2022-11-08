using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PickUpBehaviour : MonoBehaviour
    {
        public int value = 1;
        [SerializeField] private LevelManager lm;

        [SerializeField] private ParticleSystem ps;

        [SerializeField] int price = 0;

        public PickUp pickUp;
        
        private void Awake()
        { 
            if (lm == null) lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerHurtBox") && lm.playerUsables.usables[PickUp.COIN] >= price)
            {
                lm.AddPickUpToPlayer(PickUp.COIN, -price);

                lm.AddPickUpToPlayer(pickUp,value);

                if (ps != null)
                {
                    ps.transform.parent = null;
                    ps.Emit(30);
                    Destroy(ps.gameObject, 2f);
                }

                OneTimePickup OTPickup = GetComponent<OneTimePickup>();

                if (OTPickup != null)
                {
                    OTPickup.PickedUp();
                }

                Destroy(this.gameObject);
            }
        }
    }
}