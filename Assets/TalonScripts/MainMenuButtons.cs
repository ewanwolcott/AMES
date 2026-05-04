using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void Play()
    {
        animator.SetTrigger("play");
    }
}
