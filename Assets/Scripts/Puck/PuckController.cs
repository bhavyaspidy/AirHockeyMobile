using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PuckController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 12f;
    [SerializeField] private float testSpeed = 5f;
    [SerializeField] private float minimumSpeed = 2f;
    [SerializeField] private float paddleBounceSpeed = 6f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Vector2 randomDirection =
            Random.insideUnitCircle.normalized;

        rb.linearVelocity = new Vector3(
            randomDirection.x,
            0f,
            randomDirection.y
        ) * testSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        velocity.y = 0f;

        if (velocity.magnitude < minimumSpeed)
        {
            Vector2 randomDirection =
                Random.insideUnitCircle.normalized;

            velocity = new Vector3(
                randomDirection.x,
                0f,
                randomDirection.y
            ) * minimumSpeed;
        }

        if (velocity.magnitude > maxSpeed)
        {
            velocity =
                velocity.normalized * maxSpeed;
        }

        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Paddle"))
        {
            Vector3 hitDirection =
                transform.position -
                collision.transform.position;

            hitDirection.y = 0f;

            if (hitDirection.sqrMagnitude > 0.01f)
            {
                hitDirection.Normalize();

                rb.linearVelocity =
                    hitDirection * paddleBounceSpeed;
            }
        }
    }
    public void Launch()
    {
        Vector2 randomDirection =
            Random.insideUnitCircle.normalized;

        rb.linearVelocity = new Vector3(
            randomDirection.x,
            0f,
            randomDirection.y
        ) * testSpeed;
    }
}