using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;

    public GameObject interactPrompt;

    public UnityEvent onInteract;
}
