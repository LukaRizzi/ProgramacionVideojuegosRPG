using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PickUpBehaviour : MonoBehaviour
    {
        public int value = 1;
        [SerializeField] private LevelManager lm;

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
                Destroy(this.gameObject);
            }

            OneTimePickup OTPickup = GetComponent<OneTimePickup>();

            if (OTPickup != null)
            {
                OTPickup.PickedUp();
            }
        }
    }
}