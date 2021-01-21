using UnityEngine;

// When the player trigger the end of a level the level ends 
// and the next scene will be loaded(see the gameManager.CompleteLevel())
public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            gameManager.CompleteLevel();
        }
    }
}
