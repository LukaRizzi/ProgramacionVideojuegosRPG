using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public abstract class PlayerState
    {
        public abstract void StartState(PlayerStateManager manager);
        public abstract void UpdateState(PlayerStateManager manager);
    }
}