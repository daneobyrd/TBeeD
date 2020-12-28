using UnityEngine;

namespace TBeeD
{
    public class BeeController : MonoBehaviour
    {
        [SerializeField] private float currentSpeed = 0f;
        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 moveInput = new Vector2(horizontal, vertical);
            rb.velocity = moveInput * currentSpeed;
            transform.up = rb.velocity.normalized;
        }
    }
}
