using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            newScore();
        }
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            newScore(100);
        }
        if (SceneManager.GetActiveScene().name == "Level03")
        {
            newScore(250);
        }
    }

    private void newScore(int startingScore = 0)
    {
        // if the fox is falling outside or the brige the score must not increase!!!
        if (player.position.y > -1)
        {
            scoreText.text = (startingScore + player.position.z).ToString("0");
        }
    }
}
