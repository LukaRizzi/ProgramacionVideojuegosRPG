using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerHPManager : HPManager
    {
        public override int Hp
        {
            get { return hp; }
            set
            {
                hp = Mathf.Clamp(value, 0, hpMax);

                if (hp <= 0)
                {
                    OnDeath();
                }

                GameManager.Instance.livesDisplay.UpdateHearts(value);
            }
        }

        public override void OnDeath()
        {
            print("Te moriste!");
        }
    }
}