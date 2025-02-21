using UnityEngine;
using UnityEngine.UI;

public class BlackholeAlphaThreshold : MonoBehaviour
{
    private Image _blackholeImage;

    private void Awake()
    {
        _blackholeImage = GetComponent<Image>();
        _blackholeImage.alphaHitTestMinimumThreshold = 0.001f;
    }
}
