using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class EnemyStateWalking : EnemyState
    {
        public override void StartState(EnemyStateManager manager)
        {

        }

        public override void UpdateState(EnemyStateManager manager)
        {
            manager.rb.velocity = manager.moveDirection;
            manager.sr.flipX = Mathf.Sign(manager.moveDirection.x) < 0;
        }
    }
}