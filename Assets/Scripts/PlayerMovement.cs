using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float _x = Input.GetAxis("Horizontal") * speed;
            float _y = Input.GetAxis("Vertical") * speed;
            Vector2 _force = new Vector2(_x, _y);

            if (_force != Vector2.zero)
            {
                animator.SetBool("walking", true);
                rb.velocity = _force;
            }
            else
            {
                animator.SetBool("walking", false);
                rb.velocity = Vector2.zero;
            }
        }
    }
}