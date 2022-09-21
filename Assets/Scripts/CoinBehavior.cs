using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class CoinBehavior : MonoBehaviour
    {
        public int value = 1;
        [SerializeField] private LevelManager lm;

        private void Start()
        { 
        }

        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerHurtBox"))
            {
                lm.AddCoinsToPlayer(value);
                Destroy(this.gameObject);
            }
        }
    }
}