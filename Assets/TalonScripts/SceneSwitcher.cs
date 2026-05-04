using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] ScreenFader _screenFader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            _screenFader.FadeOut(ScreenFader.FadeType.Shutters);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && img.material.GetFloat("_FadeAmount") == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
