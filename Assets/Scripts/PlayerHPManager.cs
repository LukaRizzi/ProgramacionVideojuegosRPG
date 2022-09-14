using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerHPManager : HPManager
    {
        public override void OnDeath()
        {
            print("Te moriste!");
        }
    }
}