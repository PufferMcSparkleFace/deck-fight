using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    Rigidbody rb;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        Debug.Log("Crouch");
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        Debug.Log("Special");
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            playerVelocity.x = 0f;
            Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            if (movementInput.x > 0)
            {
                playerVelocity.x += 4;
            }
            if (movementInput.x < 0)
            {
                playerVelocity.x -= 4;
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}