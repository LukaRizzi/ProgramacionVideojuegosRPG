using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGUNDAV.Gameplay
{
    public class RatStateWalking : EnemyState
    {
        public override void StartState(EnemyStateManager manager)
        {

        }

        public override void UpdateState(EnemyStateManager manager)
        {
            manager.rb.velocity = manager.transform.up * manager.speed + manager.transform.right * manager.speed;

            RaycastHit2D hitWallVertical = Physics2D.Raycast(manager.transform.position, manager.transform.up, manager.raycastWallDistance, manager.whatIsSolid);
            RaycastHit2D hitWallHorizontal = Physics2D.Raycast(manager.transform.position, manager.transform.right, manager.raycastWallDistance, manager.whatIsSolid);
            if (hitWallVertical)
            {
                manager.transform.rotation = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x + 180,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z);
                ToggleSpriteRendererY(manager);
            }
            if (hitWallHorizontal){
                    manager.transform.rotation = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z+180);
            }

            Debug.DrawRay(manager.transform.position, manager.transform.up * manager.raycastWallDistance, Color.green, .01f);
            Debug.DrawRay(manager.transform.position, manager.transform.right * manager.raycastWallDistance, Color.red, .01f);
        }
        
        public override void OnCollisionWithPlayer(EnemyStateManager manager, GameObject player)
        {
            player.GetComponent<PlayerStateManager>().Attacked(manager.gameObject);
        }

        private void ToggleSpriteRendererY(EnemyStateManager manager){
            if(manager.sr.flipY == false){
                manager.sr.flipY = true;
            } else{
                manager.sr.flipY = false;
            }
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