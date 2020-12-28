using UnityEngine;

namespace TBeeD
{
    public class BeeController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0f;
        [SerializeField] private float dashForce = 0f;
        [SerializeField] private float dashDuration = 0f;
        [SerializeField] private AnimationCurve dashCurve = default;
        private float currentSpeed;
        private Rigidbody2D rb;
        private float horizontalAxis;
        private float verticalAxis;
        private Vector2 moveInput;
        private bool activatedDash;
        private float dashTimer = 0f;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            currentSpeed = moveSpeed;
        }

        void Update()
        {
            HandleInput();
        }

        void FixedUpdate()
        {
            currentSpeed = horizontalAxis == 0 && verticalAxis == 0 ? 0 : moveSpeed;

            if (horizontalAxis == 0 && verticalAxis == 0)
            {
                currentSpeed = 0;
            }
            else
            {
                transform.up = rb.velocity.normalized;
            }

            rb.velocity = moveInput * currentSpeed;

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
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            verticalAxis = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(horizontalAxis, verticalAxis).normalized;
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
