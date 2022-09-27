using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class EnemyStateManager : MonoBehaviour
        {
        public enum enemies {
            CRAB,
            RAT,
            SPIDER
        }
        public enemies enemy;
        public float speed = 2f;
        public Rigidbody2D rb;
        public EnemyHPManager hpManager;
        public SpriteRenderer sr;
        public Animator animator;

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
                case enemies.SPIDER:
                    defaultState = new SpiderStateWalking();
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