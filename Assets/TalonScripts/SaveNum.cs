using UnityEngine;

public class SaveNum : MonoBehaviour
{
    public float boolValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
