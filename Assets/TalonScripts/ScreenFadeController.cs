using UnityEngine;

public class ScreenFadeController : MonoBehaviour
{
    [SerializeField] ScreenFader _screenFader;

    [SerializeField] ScreenFader _screenFaderNormal;

    [SerializeField] SaveNum _saveNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    void Start()
    {
        if(_saveNum.boolValue == 1)
        {
            _screenFader.FadeIn(ScreenFader.FadeType.Shutters);
        }
       else if (_saveNum.boolValue == 0)
        {
            _screenFaderNormal.FadeIn(ScreenFader.FadeType.Shutters);
            _saveNum.boolValue = 1;
        }
    }
}
