using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // When the fox is hitted by the ball, it disappears!
        if(other.name == "Enemy")
        {
            this.transform.parent.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }
}
