using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPGUNDAV.Gameplay
{
    public class SpiderStateWalking : EnemyState
    {
        [SerializeField] float attackCooldown = 3f;
        private float attackCooldownLeft = 3f;

        public override void StartState(EnemyStateManager manager)
        {

        }
        
        public override void UpdateState(EnemyStateManager manager)
        {
            attackCooldownLeft -= Time.deltaTime;

            manager.rb.velocity = manager.transform.right * manager.speed;

            Quaternion turnRightOnWall = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z - 90);

            RaycastHit2D hitWall = Physics2D.Raycast(manager.transform.position, manager.transform.right, manager.raycastWallDistance, manager.whatIsSolid);
            
            if (hitWall)
            {
                manager.transform.rotation = turnRightOnWall;
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

        public override void OnSight(EnemyStateManager manager, GameObject player)
        {
            Quaternion ignore = Quaternion.Euler(
                    manager.transform.rotation.eulerAngles.x,
                    manager.transform.rotation.eulerAngles.y,
                    manager.transform.rotation.eulerAngles.z + 180);

            RaycastHit2D hitPlayer = Physics2D.Raycast(manager.transform.position, manager.transform.right, manager.raycastPlayerDistance, manager.whatIsPlayer);

            if(attackCooldownLeft <= 0f && hitPlayer){
            
                #region Random Movement

                int randomNumber = Random.Range(1,5);
                Vector3 lookAtPlayer = player.transform.position - manager.transform.position;
                Vector3 huntPlayer = lookAtPlayer * manager.speed * 2;

                if (randomNumber == 1){
                    manager.transform.right = lookAtPlayer;
                    manager.rb.velocity = huntPlayer;
                }
                else if (randomNumber == 2){
                    manager.transform.right = lookAtPlayer;
                    manager.rb.velocity = manager.transform.right;
                }
                else if (randomNumber == 3){
                    manager.transform.right = lookAtPlayer;
                    manager.rb.velocity = Vector2.zero;
                }
                else{
                    manager.transform.rotation = ignore;
                }
                #endregion

                attackCooldownLeft = attackCooldown;
                
            }

            Debug.DrawRay(manager.transform.position, manager.transform.right * manager.raycastPlayerDistance, Color.yellow, .01f);

            

            
        }
    }
}