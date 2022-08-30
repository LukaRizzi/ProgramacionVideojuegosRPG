using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateWalking : PlayerState
    {
        public override void StartState(PlayerStateManager manager)
        {
            
        }

        public override void UpdateState(PlayerStateManager manager)
        {
            float _x = Input.GetAxis("Horizontal") * manager.speed;
            float _y = Input.GetAxis("Vertical") * manager.speed;
            Vector2 _force = new Vector2(_x, _y);

            if (_force != Vector2.zero)
            {
                manager.animator.SetBool("walking", true);
                manager.rb.velocity = _force;
            }
            else
            {
                manager.animator.SetBool("walking", false);
                manager.rb.velocity = Vector2.zero;
            }
        }
    }
}