using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateResting : PlayerState
    {
        public override void StartState(PlayerStateManager manager)
        {
            manager.animator.SetBool("walking", false);
            manager.rb.velocity = Vector2.zero;
        }

        public override void UpdateState(PlayerStateManager manager)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.ChangeState(new PlayerStateWalking());
            }
        }
    }
}