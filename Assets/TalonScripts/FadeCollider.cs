using System.Collections;
using UnityEngine;

public class FadeCollider : MonoBehaviour
{
    [SerializeField] ScreenFader _screenFader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player entered fade collider");
            _screenFader.FadeOut(ScreenFader.FadeType.Shutters);
            StartCoroutine(FadeInAfterDelay(1.5f));
        }
    }
    IEnumerator FadeInAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _screenFader.FadeIn(ScreenFader.FadeType.Shutters);
    }
}


