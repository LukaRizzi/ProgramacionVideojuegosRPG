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
            manager.rb.velocity = manager.transform.up * manager.speed;

            RaycastHit2D hitWall = Physics2D.Raycast(manager.transform.position, manager.transform.up, manager.raycastWallDistance, manager.whatIsSolid);
            
            if (hitWall)
            {
                manager.transform.rotation = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z + 90);
            }

            Debug.DrawRay(manager.transform.position, manager.transform.up * manager.raycastWallDistance, Color.green, .01f);
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