using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void Play()
    {
        animator.SetTrigger("play");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Ethan()
    {
        SceneManager.LoadScene("Ethan Credits");
    }

    public void Talon()
    {
        SceneManager.LoadScene("talon credits");
    }

    public void Vince()
    {
        SceneManager.LoadScene("Vince credits");
    }

    public void Ewan()
    {
        SceneManager.LoadScene("Ewan credits");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
