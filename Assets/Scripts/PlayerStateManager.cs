using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateManager : MonoBehaviour
    {
        public LevelManager levelManager;

        public PlayerHPManager hpManager;

        public float speed = 1f;
        public Rigidbody2D rb;
        public Animator animator;
        public SpriteRenderer sr;

        public PlayerState state { get; private set; }

        public Transform swordHolder;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            ChangeState(new PlayerStateWalking());
        }

        private void Update()
        {
            state.UpdateState(this);
        }

        public void ChangeState( PlayerState newState )
        {
            state = newState;
            state.StartState(this);
        }

        public void Attacked(GameObject enemy)
        {
            state.OnAttacked(this, enemy);
        }
    }
}