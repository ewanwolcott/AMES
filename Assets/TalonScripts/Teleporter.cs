using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public Vector2 teleportLocation;

    [SerializeField] Image img;
    [SerializeField] ScreenFader _screenFader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(img.material.GetFloat("_FadeAmount"));
            _screenFader.FadeOut(ScreenFader.FadeType.Shutters);
            StartCoroutine(FadeInAfterDelay(1.5f));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && img.material.GetFloat("_FadeAmount") == 1)
        {
            collision.transform.position = teleportLocation;
        }
    }
    IEnumerator FadeInAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _screenFader.FadeIn(ScreenFader.FadeType.Shutters);
    }

}
