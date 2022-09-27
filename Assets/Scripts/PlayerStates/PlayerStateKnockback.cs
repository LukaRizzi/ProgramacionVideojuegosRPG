using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateKnockback : PlayerState
    {
        public override void StartState(PlayerStateManager manager)
        {
            manager.animator.SetBool("walking", false);
            manager.animator.SetTrigger("attacked");
            manager.animator.SetBool("knockedBack", true);
        }

        public override void UpdateState(PlayerStateManager manager)
        {
            if (manager.rb.velocity.magnitude <= .01f)
            {
                manager.animator.SetBool("knockedBack", false);
                manager.ChangeState(new PlayerStateWalking());
            }
        }

        public override void OnAttacked(PlayerStateManager manager, GameObject enemy)
        {

        }
    }
}