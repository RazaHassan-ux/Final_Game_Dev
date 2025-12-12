using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float acceleration = 10f;
    public float deceleration = 12f;
    public float gravity = -20f;
    public float airControl = 0.4f;

    [Header("Jumping")]
    public float jumpForce = 7f;
    public float coyoteTime = 0.15f;
    private float coyoteCounter;

    [Header("Ground Check")]
    public float groundCheckDistance = 0.2f;
    public LayerMask groundMask;

    [Header("Slope Handling")]
    public float slopeForce = 6f;
    public float slopeForceRayDistance = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 moveInput;
    private float currentSpeed;

    private bool isGrounded;
    private Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        CheckGround();
        GetInput();
        MovePlayer();
        ApplyGravityAndJump();
    }

    // ------------ INPUT ----------------
    void GetInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        moveInput = (forward * v + right * h).normalized;
    }

    // ------------ MOVEMENT ----------------
    void MovePlayer()
    {
        // Running or walking
        float targetSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        if (moveInput.magnitude > 0.1f)
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        else
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);

        Vector3 moveDir = moveInput * currentSpeed;

        // Allow air control
        if (!isGrounded)
            moveDir *= airControl;

        // Handle slope before moving
        //HandleSlope();

        // Combine horizontal movement with vertical velocity
        Vector3 finalMove = moveDir + new Vector3(0, velocity.y, 0);

        controller.Move(finalMove * Time.deltaTime);
    }

    // ------------ SLOPE HANDLING ----------------
    void HandleSlope()
    {
        if (isGrounded && IsOnSlope())
        {
            controller.Move(Vector3.down * slopeForce * Time.deltaTime);
        }
    }

    bool IsOnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, slopeForceRayDistance))
        {
            return hit.normal != Vector3.up;
        }
        return false;
    }

    // ------------ JUMP & GRAVITY ----------------
    void ApplyGravityAndJump()
    {
        // Grounded reset
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Coyote time counter
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        // Jump input
        if (Input.GetButtonDown("Jump") && coyoteCounter > 0f)
        {
            velocity.y = jumpForce;
            coyoteCounter = 0f;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
    }

    // ------------ GROUND CHECK ----------------
    void CheckGround()
    {
        // Using CharacterController's built-in grounded check
        isGrounded = controller.isGrounded;

        // Optional: Physics.CheckSphere version
        // isGrounded = Physics.CheckSphere(transform.position + Vector3.down * 0.1f,
        //                                  groundCheckDistance, groundMask);
    }
}
