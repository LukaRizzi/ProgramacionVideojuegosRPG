using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{

    public abstract class EnemyState
    {
        public abstract void StartState(EnemyStateManager manager);
        public abstract void UpdateState(EnemyStateManager manager);
        public abstract void OnCollisionWithPlayer(EnemyStateManager manager, GameObject player);
        public abstract void OnAttacked(EnemyStateManager manager, GameObject player);

    }
}