using UnityEngine;
using UnityEngine.SceneManagement;

// I made this fuction to define the behaviour of the buttons in Credits and Gameover scenes
// Only one script because they are using the same function
public class CreditsGameOverButtons : MonoBehaviour
{
    public void Start()
    {
        // The cursor return visible beacuse in the levels of the game is unvisible
        Cursor.visible = true;
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Menu()
    {
        Debug.Log("Back to the menu!");
        SceneManager.LoadScene("Menu");
    }
}
