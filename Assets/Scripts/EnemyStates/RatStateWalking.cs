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
            Vector3 dir = manager.transform.up * manager.speed + manager.transform.right * manager.speed;

            RaycastHit2D hitWall = Physics2D.Raycast(manager.transform.position, dir, manager.raycastWallDistance, manager.whatIsSolid);

            if (hitWall)
            {
                Vector3 direccion = Quaternion.Euler(0, 0, 45) * Vector3.Reflect(dir, hitWall.normal);
                manager.transform.rotation = Quaternion.LookRotation(Vector3.forward, direccion);

                dir = manager.transform.up * manager.speed + manager.transform.right * manager.speed;

                manager.transform.GetChild(0).rotation = Quaternion.identity;
            }

            manager.rb.velocity = dir;  

            //Debug.DrawRay(manager.transform.position, dir.normalized * manager.raycastWallDistance, Color.green, .01f);
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