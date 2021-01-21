using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // The enemy is a dangerous rock that run forward following the player trying to crush him!
        rb.AddForce(Vector3.forward * Time.deltaTime);
    }

    // The ball must be not effected of collision with the other objects
    // The ball moves at constant speed equal to the run speed of the fox
    private void OnCollisionExit(Collision collision)
    {
        Vector3 constantSpeed = rb.velocity;
        constantSpeed = constantSpeed.normalized;
        constantSpeed *= 6.0f;
        rb.velocity = constantSpeed;
    }
}
