using UnityEngine;

namespace TBeeD
{
    public class BeeController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0f;
        [SerializeField] private float dashForce = 0f;
        [SerializeField] private float dashDuration = 0f;
        [SerializeField] private AnimationCurve dashCurve = default;
        private Rigidbody2D rb;
        private Vector2 moveInput;
        private bool activatedDash;
        private float dashTimer = 0f;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            HandleInput();
        }

        void FixedUpdate()
        {
            rb.velocity = moveInput * moveSpeed;
            transform.up = rb.velocity.normalized;

            if (activatedDash)
            {
                Dash();
            }
        }

        void HandleInput()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                activatedDash = true;
            }
        }

        void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(horizontal, vertical).normalized;
        }

        void Dash()
        {
            if (activatedDash)
            {
                dashTimer += Time.fixedDeltaTime;

                if (dashTimer >= dashDuration)
                {
                    activatedDash = false;
                    dashTimer = 0f;
                }

                rb.AddForce(transform.up * dashForce * dashCurve.Evaluate(dashTimer / dashDuration), ForceMode2D.Impulse);
            }
        }
    }
}
