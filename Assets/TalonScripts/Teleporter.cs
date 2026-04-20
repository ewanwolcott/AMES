using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public Vector2 teleportLocation;

    [SerializeField] Image img;
    [SerializeField] ScreenFader _screenFader;

    [SerializeField] bool floating = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(floating)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            _screenFader.FadeOut(ScreenFader.FadeType.Shutters);
            StartCoroutine(FadeInAfterDelay(1.5f));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && img.material.GetFloat("_FadeAmount") == 1)
        {
            if (floating)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            }
            collision.gameObject.GetComponent<PlayerMovement>().canMove = true;
            collision.transform.position = teleportLocation;
        }
    }
    IEnumerator FadeInAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _screenFader.FadeIn(ScreenFader.FadeType.Shutters);
    }

}
