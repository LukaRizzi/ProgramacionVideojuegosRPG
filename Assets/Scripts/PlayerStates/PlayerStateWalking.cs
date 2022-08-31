using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateWalking : PlayerState
    {
        public override void StartState(PlayerStateManager manager)
        {

        }

        public override void UpdateState(PlayerStateManager manager)
        {
            float _x = Input.GetAxis("Horizontal") * manager.speed;
            float _y = Input.GetAxis("Vertical") * manager.speed;
            Vector2 _force = new Vector2(_x, _y);

            if (_force != Vector2.zero)
            {
                manager.animator.SetBool("walking", true);
                manager.rb.velocity = _force;
            }
            else
            {
                manager.animator.SetBool("walking", false);
                manager.rb.velocity = Vector2.zero;
            }

            bool _canRest = false;

            foreach(GameObject bonfire in manager.levelManager.bonfires)
            {
                if (Vector2.Distance(bonfire.transform.position, manager.transform.position) < 2)
                    _canRest = true;
            }

            if (_canRest && Input.GetKeyDown(KeyCode.Space))
            {
                manager.ChangeState(new PlayerStateResting());
                //manager.sr.flipX = bonfire.transform.position.x < manager.transform.position.x;
            }
        }
    }
}