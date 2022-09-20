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
        public EnemyHPManager hpManager;
        public SpriteRenderer sr;

        public float raycastWallDistance = 1f;

        public LayerMask whatIsSolid;

        public EnemyState defaultState;
        private EnemyState state;

        private void Start()
        {
            switch(enemy){
                case enemies.CRAB:
                    defaultState = new CrabStateWalking();
                    break;
                case enemies.RAT:
                    defaultState = new RatStateWalking();
                    break;
                default:
                    Debug.LogError("ERROR: ENEMIGO " + enemy.ToString() + " NO TIENE ESTADO INICIAL");
                    break;
            }

            state = defaultState;
            state.StartState(this);
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

        public void Attacked(GameObject player) 
        {
            state.OnAttacked(this, player);
        }
    }
}