using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float walkSpeed = 20.0f;

    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;

    public float speedSmoothTime = 0.2f;
    private float speedSmoothVelocity;
    private float currentSpeed;

    private Animator animator;

    private CharacterController controller;
    private float velocityY;
    private float gravity = -12.0f;

    private float jumpHeight = 1;

    private float startingAnimationDuration = 2.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // If the player fall off the bridge i call the LevelFailed function
        if(transform.position.y <= -1)
        {
            FindObjectOfType<GameManager>().LevelFailed();
        }
        
        // Restriction on player movement during the initial animation
        if(Time.time < startingAnimationDuration)
        {
            controller.Move((transform.forward * 6) * Time.deltaTime);
            animator.SetFloat("speedPercent", 1, speedSmoothTime, Time.deltaTime);
            return;
        }

        Vector2 input = new Vector2(-Input.GetAxisRaw("Horizontal"), walkSpeed);
        Vector2 inputDir = input.normalized;

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (inputDir != Vector2.zero)
        {
            // I add the factor 10 to speed up the movement during the rotation to enable the "avoiding the obstacles"
            float targetRotation = 10 * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime); 
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        // If the fox runs it goes 3 times faster (the same speed of the ball)! 
        float targetSpeed = ((running) ? 6 : 2) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        velocityY += gravity * Time.deltaTime;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }
}
