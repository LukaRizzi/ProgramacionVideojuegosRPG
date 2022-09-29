using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGUNDAV.Gameplay
{
    public class SpiderStateWalking : EnemyState
    {
        public override void StartState(EnemyStateManager manager)
        {

        }
        
        public override void UpdateState(EnemyStateManager manager)
        {
            Quaternion clockWise = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z - 90);

            manager.rb.velocity = manager.transform.right * manager.speed;

            RaycastHit2D hitWall = Physics2D.Raycast(manager.transform.position, manager.transform.right, manager.raycastWallDistance, manager.whatIsSolid);
            
            if (hitWall)
            {
                manager.transform.rotation = clockWise;
            }

            Debug.DrawRay(manager.transform.position, manager.transform.right * manager.raycastWallDistance, Color.green, .01f);
        }

        public override void OnCollisionWithPlayer(EnemyStateManager manager, GameObject player)
        {
            player.GetComponent<PlayerStateManager>().Attacked(manager.gameObject);
        }

        public override void OnAttacked(EnemyStateManager manager, GameObject player)
        {
            manager.hpManager.Hp--;

            Vector2 dir = (manager.transform.position - player.transform.position).normalized;
            manager.rb.velocity = dir * 6;

            manager.ChangeState(new EnemyStateKnockback());
        }
    }
}