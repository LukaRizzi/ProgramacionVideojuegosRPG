using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class EnemyStateManager : MonoBehaviour
    {
        public float speed = 2f;
        public Rigidbody2D rb;
        public EnemyHPManager hpManager;

        public float raycastWallDistance = 1f;

        public LayerMask whatIsSolid;

        private EnemyState state = new EnemyStateWalking();

        private void Start()
        {
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