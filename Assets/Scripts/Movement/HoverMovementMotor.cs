using UnityEngine;

public class HoverMovementMotor : MovementMotor
{
    //public var movement : MoveController;
    public float flyingSpeed = 5.0f;
    public float flyingSnappyness = 2.0f;
    public float turningSpeed = 3.0f;
    public float turningSnappyness = 3.0f;
    public float bankingAmount = 1.0f;

    private Rigidbody rb;
    private Vector3 previousAngularVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousAngularVelocity = rb.angularVelocity;
    }

    private void FixedUpdate()
    {
        // Handle the movement of the character
        Vector3 targetVelocity = movementDirection * flyingSpeed;
        Vector3 deltaVelocity = targetVelocity - rb.velocity;
        rb.AddForce(deltaVelocity * flyingSnappyness, ForceMode.Acceleration);

        // Make the character rotate towards the target rotation
        Vector3 facingDir = facingDirection != Vector3.zero ? facingDirection : movementDirection;
        if (facingDir != Vector3.zero)
        {
            Vector3 currentAngularVelocity = rb.angularVelocity;
            float deltaTime = Time.fixedDeltaTime;
            Vector3 deltaAngularVelocity = (currentAngularVelocity - previousAngularVelocity) / deltaTime;
            previousAngularVelocity = currentAngularVelocity;

            float banking = Vector3.Dot(movementDirection, -transform.right);
            rb.AddTorque(
                deltaAngularVelocity * turningSnappyness + transform.forward * (banking * bankingAmount));
        }
    }

    private void OnCollisionStay(Collision other)
    {
        // Move up if colliding with static geometry
        if (other.rigidbody == null)
        {
            rb.velocity += Vector3.up * Time.deltaTime * 50;
        }
    }
}