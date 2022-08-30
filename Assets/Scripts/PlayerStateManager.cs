using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateManager : MonoBehaviour
    {
        public float speed = 1f;
        public Rigidbody2D rb;
        public Animator animator;

        private PlayerState state = new PlayerStateWalking();
        public PlayerStateWalking walkingState = new PlayerStateWalking();

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            state.StartState(this);
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
    }
}