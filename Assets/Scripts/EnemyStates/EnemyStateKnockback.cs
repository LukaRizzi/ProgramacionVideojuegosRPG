using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay

{
    public class EnemyStateKnockback : EnemyState
    {
        public override void StartState(EnemyStateManager manager) 
        {

        }

        public override void UpdateState(EnemyStateManager manager) 
        {
            if (manager.rb.velocity.magnitude <= .01f)
            {
                manager.ChangeState(manager.defaultState);
            }
        }

        public override void OnCollisionWithPlayer(EnemyStateManager manager, GameObject player) 
        {
            
        }

        public override void OnAttacked(EnemyStateManager manager, GameObject player)
        {
            
        }
    }
}