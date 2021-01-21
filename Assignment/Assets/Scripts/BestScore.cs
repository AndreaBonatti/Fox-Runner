using UnityEngine;
using UnityEngine.UI;

// Class to show the best score of a player in case of game over
public class BestScore : MonoBehaviour
{
    public Text bestScore;

    private void Start()
    {
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
