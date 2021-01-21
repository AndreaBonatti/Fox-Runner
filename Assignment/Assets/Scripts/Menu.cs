using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        // The player starts with 3 of health(== 3 hearts) and his initial score is 0
        PlayerPrefs.SetInt("Health", 3);
        PlayerPrefs.SetInt("BestScore", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
