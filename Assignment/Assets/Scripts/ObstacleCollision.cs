using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // The ball makes disappears all the obastacles
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Enemy")
        {
            this.gameObject.SetActive(false);
        }
    }
}
