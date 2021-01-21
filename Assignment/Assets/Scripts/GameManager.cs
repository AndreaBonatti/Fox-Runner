using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool levelFailed = false;
    private bool levelComplete = false;

    public float restartDelay = 2.0f;
    public GameObject completeLevelUI, heart_1, heart_2, heart_3, enemy;
    public Text score;

    // The player's level of health is rappresented by 3 hearts
    // The player starts with 3 hearts, if it looses all the hearts it dies and it is game over
    private void Update()
    {
        if (!levelComplete)
        {
            switch (PlayerPrefs.GetInt("Health"))
            {
                case 3:
                    heart_1.SetActive(true);
                    heart_2.SetActive(true);
                    heart_3.SetActive(true);
                    break;
                case 2:
                    heart_1.SetActive(true);
                    heart_2.SetActive(true);
                    heart_3.SetActive(false);
                    break;
                case 1:
                    heart_1.SetActive(true);
                    heart_2.SetActive(false);
                    heart_3.SetActive(false);
                    break;
                case 0:
                    heart_1.SetActive(false);
                    heart_2.SetActive(false);
                    heart_3.SetActive(false);
                    SceneManager.LoadScene("GameOver");
                    break;
            }
        }
    }

    // If the player get crushed from the ball or falls down from the bridge it looses 1 heart and i save his actual best score
    public void LevelFailed()
    {
        if (levelFailed == false)
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 1);
            if (PlayerPrefs.GetInt("BestScore") < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("BestScore", int.Parse(score.text));
            }
            levelFailed = true;
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        levelComplete = true;
        heart_1.SetActive(false);
        heart_2.SetActive(false);
        heart_3.SetActive(false);
        enemy.SetActive(false);
        completeLevelUI.SetActive(true);
    }
}
