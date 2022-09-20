using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class EnemyStateManager : MonoBehaviour
        {
        public enum enemies {
            CRAB,
            RAT
        }
        public enemies enemy;
        public float speed = 2f;
        public Rigidbody2D rb;

        public SpriteRenderer sr;
        public float raycastWallDistance = 1f;

        public LayerMask whatIsSolid;

        private EnemyState state;

        private void Start()
        {
            
            switch(enemy){
                case enemies.CRAB:
                    state = new CrabStateWalking();
                    break;
                case enemies.RAT:
                    state = new RatStateWalking();
                    break;
                default: break;
            }
        }

        private void Update()
        {
            state.UpdateState(this);
        }

        public void ChangeState(EnemyState newState)
        {
            state = newState;
            state.StartState(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerHurtBox"))
            {
                state.OnCollisionWithPlayer(this, collision.transform.parent.gameObject);
            }
        }

        public void Attacked(GameObject enemy)
        {
        }
    }
}