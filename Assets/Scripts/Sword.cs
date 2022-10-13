using System;
using UnityEngine;
using UnityEditor;

namespace RPGUNDAV.Gameplay
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private KeyCode attackKey;
        [SerializeField] private SpriteRenderer spriteRenderer;
        public float secondsToFullyCharge = 1;
        public float secondsToStartCharging = 0.1f;
        public float idleSpeed = 1;
        public float normalAttackSpeed = 2;
        public float chargedAttackSpeed = 1;
        private Boolean _isNewAttack = true;
        private float _timeStartCharge;

        private Quaternion _originalRotation;
        private Color _originalColor;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            anim.SetFloat("idleSpeed",idleSpeed);
            anim.SetFloat("normalAttackSpeed", normalAttackSpeed);
            anim.SetFloat("chargeSpeed", 1/secondsToFullyCharge);
            anim.SetFloat("chargedAttackSpeed", chargedAttackSpeed);
            _originalRotation = transform.rotation;
            _originalColor = spriteRenderer.color;
        }

        private void Update()
        {
            if (Input.GetKeyDown(attackKey)){
                Attack();
            }
    
            if (Input.GetKey(attackKey)){
                Charge();
            }  

            if(Input.GetKeyUp(attackKey)){
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
            anim.SetBool("charge",false);
            anim.SetTrigger("normalAttack");
            _isNewAttack = true;
        }

        private void Charge(){
            if(_isNewAttack){
                _timeStartCharge = Time.fixedTime;
                anim.SetBool("charge",true); 
            }
            _isNewAttack = false;
        }

        private void AttackCharged(){
            if(Time.fixedTime >= _timeStartCharge + secondsToFullyCharge){
                anim.SetTrigger("chargedAttack");
            }else{
                anim.SetBool("charge",false);
            }
        }

        public void Reset(){
           transform.rotation = _originalRotation;
           spriteRenderer.color = _originalColor;
        }
    }
}