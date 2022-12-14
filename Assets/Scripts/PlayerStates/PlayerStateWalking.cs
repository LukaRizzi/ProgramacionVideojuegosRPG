using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateWalking : PlayerState
    {
        public override void StartState(PlayerStateManager manager)
        {
            manager.swordHolder.gameObject.SetActive(true);
        }

        public override void UpdateState(PlayerStateManager manager)
        {
            #region MOVEMENT
            float _x = Input.GetAxis("Horizontal") * manager.speed;
            float _y = Input.GetAxis("Vertical") * manager.speed;
            Vector2 _force = new Vector2(_x, _y);

            if (_force != Vector2.zero)
            {
                manager.animator.SetBool("walking", true);
                manager.rb.velocity = _force;
                manager.sr.flipX = Mathf.Sign(_force.x) < 0;
            }
            else
            {
                manager.animator.SetBool("walking", false);
                manager.rb.velocity = Vector2.zero;
            }
            #endregion

            #region ROTATE_SWORD

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 vectorToTarget = mousePosition - manager.swordHolder.position;
            
            if (Vector3.Dot(vectorToTarget, Vector3.right) > 0)
            {
                manager.swordHolder.localScale = Vector3.one;
            }
            else
            {
                manager.swordHolder.localScale = new Vector3(-1, 1, 1);
                vectorToTarget *= -1;
            }

            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            manager.swordHolder.rotation = q;

            #endregion

            #region REST_CHECK
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (GameObject bonfire in manager.levelManager.bonfires)
                {
                    if (Vector2.Distance(bonfire.transform.position, manager.transform.position) < 2)
                    {
                        manager.sr.flipX = bonfire.transform.position.x < manager.transform.position.x;
                        manager.swordHolder.localScale = new Vector3(manager.sr.flipX ? -1 : 1, 1, 1);
                        manager.ChangeState(new PlayerStateResting());
                        manager.swordHolder.gameObject.SetActive(false);
                    }
                }
            }
            #endregion
        }

        public override void OnAttacked(PlayerStateManager manager, GameObject enemy)
        {
            manager.hpManager.Hp--;
            //manager.levelManager.displayLives.RemoveHeart();

            Vector2 dir = (manager.transform.position - enemy.transform.position).normalized;
            manager.rb.velocity = dir * 10;

            manager.ChangeState(new PlayerStateKnockback());
            manager.swordHolder.gameObject.SetActive(false);
            manager.swordHolder.gameObject.GetComponentInChildren<Sword>().Reset();
        }
    }
}