using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class EnemyHPManager : HPManager
    {
        public override void OnDeath()
        {
            Destroy(this.gameObject);
        }
    }
}