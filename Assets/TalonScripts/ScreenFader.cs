using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public float FadeDuration = 1f;

    private int _fadeAmount = Shader.PropertyToID("_FadeAmount");

    private int _useShutters = Shader.PropertyToID("_UseShutters");

    private int? _lastEffect;
}

