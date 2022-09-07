using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGUNDAV.Gameplay
{
    public class EnemyStateWalking : EnemyState
    {
        public override void StartState(EnemyStateManager manager)
        {

        }

        public override void UpdateState(EnemyStateManager manager)
        {
            manager.rb.velocity = manager.transform.right * manager.speed;

            RaycastHit2D hit = Physics2D.Raycast(manager.transform.position, manager.transform.right, manager.raycastDistance);

            if (hit)
            {
                manager.transform.rotation = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z + 180);
            }

            Debug.DrawRay(manager.transform.position, manager.transform.right * manager.raycastDistance, Color.green, .01f);
        }
    }
}