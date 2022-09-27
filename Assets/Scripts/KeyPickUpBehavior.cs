using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class KeyPickUpBehavior : MonoBehaviour
    {
        public int value = 1;
        [SerializeField] private LevelManager lm;

        private void Awake()
        { 
            if (lm == null) lm = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerHurtBox"))
            {
                lm.AddKeysToPlayer(value);
                Destroy(this.gameObject);
            }
        }
    }
}