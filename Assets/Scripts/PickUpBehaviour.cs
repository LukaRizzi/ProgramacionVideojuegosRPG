using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PickUpBehaviour : MonoBehaviour
    {
        public int value = 1;
        [SerializeField] private LevelManager lm;

        [SerializeField] private ParticleSystem particleSystem;

        public PickUp pickUp;
        
        private void Awake()
        { 
            if (lm == null) lm = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerHurtBox"))
            {
                lm.AddPickUpToPlayer(pickUp,value);

                if (particleSystem != null)
                {
                    particleSystem.transform.parent = null;
                    particleSystem.Emit(30);
                    Destroy(particleSystem.gameObject, 2f);
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