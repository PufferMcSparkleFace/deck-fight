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
    public GameObject playerManager;
    public GameObject otherPlayer;
    public Vector3 sideSwapCheck;

    public bool isCrouching = false;
    public bool isJumping = false;
    public bool isBlocking = false;
    public bool isFacingRight = true;
    public bool superCheck1 = false;
    public bool superCheck2 = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        playerManager = GameObject.FindGameObjectWithTag("Player Manager");
        otherPlayer = GameObject.FindGameObjectWithTag("Player 1");
        if (otherPlayer == null)
        {
            this.gameObject.tag = "Player 1";
        }
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
        if (context.started)
        {
            isCrouching = true;
        }
        if (context.canceled)
        {
            isCrouching = false;
        }
    }


    void Update()
    {
        sideSwapCheck = playerManager.transform.InverseTransformPoint(this.transform.position);

        if(sideSwapCheck.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }
        if(sideSwapCheck.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingRight = false;
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0 && isCrouching == false)
        {
            playerVelocity.y = 0f;
            playerVelocity.x = 0f;
            isJumping = false;
            Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        if(isFacingRight == true)
        {
            if (movementInput.x >= 0)
            {
                isBlocking = false;
            }
            else if (movementInput.x < 0)
            {
                isBlocking = true;
            }
        }
        else
        {
            if (movementInput.x > 0)
            {
                isBlocking = true;
            }
            else if (movementInput.x <= 0)
            {
                isBlocking = false;
            }
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

            isJumping = true;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            superCheck1 = true;
        }
        if (context.canceled)
        {
            superCheck1 = false;
        }

        if (isJumping == true)
        {
            Debug.Log("jN");
            return;
        }

        if (superCheck2 == true)
        {
            Debug.Log("N+S");
            return;
        }


        if (isFacingRight)
        {
            if (isCrouching == true)
            {
                if (movementInput.x > 0)
                {
                    Debug.Log("3N");
                }
                else if (movementInput.x < 0)
                {
                    Debug.Log("1N");
                }
                else if (movementInput.x == 0)
                {
                    Debug.Log("2N");
                }

                return;
            }

            if (movementInput.x > 0)
            {
                Debug.Log("6N");
            }
            else if (movementInput.x < 0)
            {
                Debug.Log("4N");
            }
            else if (movementInput.x == 0)
            {
                Debug.Log("5N");
            }
        }

        if (isFacingRight == false)
        {
            if(isCrouching == true)
            {
                if (movementInput.x > 0)
                {
                    Debug.Log("1N");
                }
                else if (movementInput.x < 0)
                {
                    Debug.Log("3N");
                }
                else if (movementInput.x == 0)
                {
                    Debug.Log("2N");
                }

                return;
            }

            if (movementInput.x > 0)
            {
                Debug.Log("4N");
            }
            else if (movementInput.x < 0)
            {
                Debug.Log("6N");
            }
            else if(movementInput.x == 0)
            {
                Debug.Log("5N");
            }
        }
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            superCheck2 = true;
        }
        if (context.canceled)
        {
            superCheck2 = false;
        }

        if (isJumping == true)
        {
            Debug.Log("jS");
            return;
        }

        if (superCheck1 == true)
        {
            Debug.Log("N+S");
            return;
        }


        if (isFacingRight)
        {
            if(isCrouching == true)
            {
                if (movementInput.x > 0)
                {
                    Debug.Log("3S");
                }
                else if (movementInput.x < 0)
                {
                    Debug.Log("1S");
                }
                else if (movementInput.x == 0)
                {
                    Debug.Log("2S");
                }

                return;
            }

            if (movementInput.x > 0)
            {
                Debug.Log("6S");
            }
            else if (movementInput.x < 0)
            {
                Debug.Log("4S");
            }
            else if (movementInput.x == 0)
            {
                Debug.Log("5S");
            }
        }

        if (isFacingRight == false)
        {
            if (isCrouching == true)
            {
                if (movementInput.x > 0)
                {
                    Debug.Log("1S");
                }
                else if (movementInput.x < 0)
                {
                    Debug.Log("3S");
                }
                else if (movementInput.x == 0)
                {
                    Debug.Log("2S");
                }

                return;
            }

            if (movementInput.x > 0)
            {
                Debug.Log("4S");
            }
            else if (movementInput.x < 0)
            {
                Debug.Log("6S");
            }
            else if (movementInput.x == 0)
            {
                Debug.Log("5S");
            }
        }
    }
}