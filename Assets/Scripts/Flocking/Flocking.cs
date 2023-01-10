using UnityEngine;

public class Flocking : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float maxSteer = 5f;
    public float neighborRadius = 10f;
    public float alignmentWeight = 1f;
    public float cohesionWeight = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Find all nearby boids
        var neighbors = Physics.OverlapSphere(transform.position, neighborRadius);

        // Calculate average alignment and cohesion vectors
        var alignment = Vector3.zero;
        var cohesion = Vector3.zero;
        var neighborCount = 0;
        foreach (var neighbor in neighbors)
        {
            var neighborRb = neighbor.GetComponent<Rigidbody>();
            if (neighborRb != rb)
            {
                // Add to the alignment vector
                alignment += neighborRb.velocity;

                // Add to the cohesion vector
                cohesion += neighborRb.position;

                // Keep track of the number of neighbors
                neighborCount++;
            }
        }

        // Calculate the final alignment and cohesion vectors
        if (neighborCount > 0)
        {
            // Normalize the alignment vector
            alignment /= neighborCount;
            alignment -= rb.velocity;
            alignment = Vector3.ClampMagnitude(alignment, maxSteer);

            // Normalize the cohesion vector
            cohesion /= neighborCount;
            cohesion -= rb.position;
            cohesion = Vector3.ClampMagnitude(cohesion, maxSteer);
        }

        // Calculate the final steering vector
        var steering = alignment * alignmentWeight + cohesion * cohesionWeight;

        // Add the steering vector to the current velocity and clamp the result
        rb.velocity = Vector3.ClampMagnitude(rb.velocity + steering, maxSpeed);
    }
}
