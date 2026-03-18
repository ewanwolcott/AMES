using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused;

    [SerializeField] private GameObject _pauseMenu;

    public void Pause()
    {
        _isPaused = true;
        _pauseMenu.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _isPaused = false;
        _pauseMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        _pauseMenu.SetActive(_isPaused);

        Time.timeScale = _isPaused ? 0f : 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
