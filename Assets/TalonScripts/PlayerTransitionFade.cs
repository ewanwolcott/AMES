using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTransitionFade : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] ScreenFader _screenFader;

    public void transition()
    {
        _screenFader.FadeOut(ScreenFader.FadeType.Shutters);
    }
    private void Update()
    {
        if (img.material.GetFloat("_FadeAmount") == 1)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}

