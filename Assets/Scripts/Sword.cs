using System;
using UnityEngine;
using UnityEditor;

namespace RPGUNDAV.Gameplay
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        public int secondsToFullyCharge = 1;
        public float idleSpeed = 1;
        public float normalAttackSpeed = 3;
        public float chargedAttackSpeed = 1;

        private float timeWhenKeyPressed;

        private bool isCharging = false;

        private AnimationClip clip;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            anim.SetFloat("idleSpeed",idleSpeed);
            anim.SetFloat("normalAttackSpeed", normalAttackSpeed);
            anim.SetFloat("chargeSpeed", 1/secondsToFullyCharge);
            anim.SetFloat("chargedAttackSpeed", chargedAttackSpeed);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V)){
                anim.SetTrigger("normalAttack");
                timeWhenKeyPressed = Time.fixedTime;
                isCharging=true;
            }
            if (Input.GetKey(KeyCode.V)){
                if(isCharging){
                    anim.SetBool("charge",true);
                }
            }  

            if(Input.GetKeyUp(KeyCode.V)){
                if(Time.fixedTime >= timeWhenKeyPressed + secondsToFullyCharge ){
                    anim.SetTrigger("chargedAttack");
                }
                anim.SetBool("charge",false);
                isCharging=false;
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {   
            GameObject collided = collision.gameObject;
            
            if (collided.layer == 7)
            {
                EnemyStateManager enemyManager = collision.GetComponent<EnemyStateManager>();
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                enemyManager.Attacked(player);
            }
        }
    }
}