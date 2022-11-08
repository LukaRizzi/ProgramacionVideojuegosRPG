using System;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private string attackButton;
        public float secondsToFullyCharge = 1;
        public float secondsToStartCharging = 0.1f;
        public float idleSpeed = 1;
        public float normalAttackSpeed = 2;
        public float chargedAttackSpeed = 1;
        private Boolean _isNewAttack = true;
        private float _timeStartCharge;
        private Quaternion _originalRotation;
        private Color _originalColor;
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            animator.SetFloat("idleSpeed",idleSpeed);
            animator.SetFloat("normalAttackSpeed", normalAttackSpeed);
            animator.SetFloat("chargeSpeed", 1/secondsToFullyCharge);
            animator.SetFloat("chargedAttackSpeed", chargedAttackSpeed);
            _originalRotation = transform.rotation;
            _originalColor = spriteRenderer.color;
        }

        private void Update()
        {
            if (Input.GetButtonDown(attackButton)){
                Attack();
            }
    
            if (Input.GetButton(attackButton)){
                Charge();
            }  

            if(Input.GetButtonUp(attackButton)){
                AttackCharged();
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

        private void Attack(){
            animator.SetBool("charge",false);
            animator.SetTrigger("normalAttack");
            _isNewAttack = true;
        }

        private void Charge(){
            if(_isNewAttack){
                _timeStartCharge = Time.fixedTime;
                animator.SetBool("charge",true); 
            }
            _isNewAttack = false;
        }

        private void AttackCharged(){
            if(Time.fixedTime >= _timeStartCharge + secondsToFullyCharge){
                animator.SetTrigger("chargedAttack");
            }else{
                animator.SetBool("charge",false);
            }
        }

        public void Reset(){
           transform.rotation = _originalRotation;
           spriteRenderer.color = _originalColor;
        }
    }
}