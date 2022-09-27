using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class BombPickUpBehavior : MonoBehaviour
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
                lm.AddBombsToPlayer(value);
                Destroy(this.gameObject);
            }
        }
    }
}