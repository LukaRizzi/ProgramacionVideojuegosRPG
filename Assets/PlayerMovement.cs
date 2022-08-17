using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float _x = Input.GetAxis("Horizontal") * speed;
        float _y = 0;
        Vector2 _force = new Vector2(_x, _y);

        rb.AddForce(_force);
    }
}