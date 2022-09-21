using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PickUpManager : MonoBehaviour
        {
        public enum pickups {
            BOMB,
            COIN,
            KEY
        }
        public pickups pickup;
        public int quantity = 1;
        public int currencyValue = 0;
        public SpriteRenderer sr;
        public LayerMask whatIsSolid;
        [SerializeField] private LevelManager lm;
        private PickUpState state;

        private void Start()
        { 
            switch(pickup){
                case pickups.COIN:
                    state = new CoinStateIdle();
                    break;
                /*case pickups.BOMB:
                    state = new RatStateWalking();
                    break;
                case pickups.KEY:
                    state = new RatStateWalking();
                    break;*/
                default: break;
            }
        }

        private void Update()
        {
            state.UpdateState(this);
        }

        public void ChangeState(PickUpState newState)
        {
            state = newState;
            state.StartState(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerHurtBox"))
            {
                state.OnCollisionWithPlayer(this, collision.transform.parent.gameObject);
                lm.AddCoinsToPlayer(currencyValue);
                Destroy(this.gameObject);
            }
        }
    }
}