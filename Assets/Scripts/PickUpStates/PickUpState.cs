using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{

    public abstract class PickUpState
    {
        public abstract void StartState(PickUpManager manager);
        public abstract void UpdateState(PickUpManager manager);
        public abstract void OnCollisionWithPlayer(PickUpManager manager, GameObject player);

    }
}