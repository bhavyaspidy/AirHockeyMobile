using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PaddleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float touchMoveSpeed = 20f;
    [SerializeField] private bool playerTwo = false;

    // Left / right across the table
    [SerializeField] private float minZ = -5f;
    [SerializeField] private float maxZ = 5f;

    // Player half boundaries
    [SerializeField] private float minX = -2.7f;
    [SerializeField] private float maxX = 2.7f;

    private Rigidbody rb;
    private Vector3 movement;

    private Vector2 touchPosition;
    private bool isTouching;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Keyboard.current == null)
        {
            movement = Vector3.zero;
            return;
        }

        float horizontal = 0f;
        float vertical = 0f;

        if (!playerTwo)
        {
            if (Keyboard.current.sKey.isPressed)
                horizontal = -1f;

            if (Keyboard.current.wKey.isPressed)
                horizontal = 1f;

            if (Keyboard.current.aKey.isPressed)
                vertical = -1f;

            if (Keyboard.current.dKey.isPressed)
                vertical = 1f;
        }
        else
        {
            if (Keyboard.current.downArrowKey.isPressed)
                horizontal = -1f;

            if (Keyboard.current.upArrowKey.isPressed)
                horizontal = 1f;

            if (Keyboard.current.leftArrowKey.isPressed)
                vertical = -1f;

            if (Keyboard.current.rightArrowKey.isPressed)
                vertical = 1f;
        }

        // Keyboard vertical = X movement
        // Keyboard horizontal = Z movement

        movement = new Vector3(
            vertical,
            0f,
            horizontal
        );
        if (isTouching)
        {
            Vector3 worldPosition =
                Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        touchPosition.x,
                        touchPosition.y,
                        15f
                    )
                );

            Vector3 direction =
                worldPosition - transform.position;

            direction.y = 0f;

            movement = Vector3.ClampMagnitude(
                 new Vector3(direction.x, 0f, direction.z),
            1f
            ) *(touchMoveSpeed / moveSpeed);
        }
        movement = Vector3.ClampMagnitude(movement, 1f);
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition =
            rb.position +
            movement * moveSpeed * Time.fixedDeltaTime;

        // X = player's half
        if (playerTwo)
        {
            targetPosition.x =
                Mathf.Clamp(targetPosition.x, 0.5f, maxX);
        }
        else
        {
            targetPosition.x =
                Mathf.Clamp(targetPosition.x, minX, -0.5f);
        }

        // Z = left / right
        targetPosition.z =
            Mathf.Clamp(targetPosition.z, minZ, maxZ);

        targetPosition.y = 0.6f;

        rb.MovePosition(targetPosition);
    }

    public void SetTouchPosition(Vector2 position)
    {
        touchPosition = position;
        isTouching = true;
    }

    public void StopTouch()
    {
        isTouching = false;
    }
}