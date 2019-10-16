using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to a UI element on a health bar or similarly controlled stat.
/// </summary>
public class BarController : MonoBehaviour
{
    /// <summary>
    /// Image of the bar that is manipulated to move the bar.
    /// </summary>
    Image hpbar;

    /// <summary>
    /// Obtains a reference to the bar image.
    /// </summary>
    private void Awake()
    {
        hpbar = GetComponent<Image>();
    }

    /// <summary>
    /// Controls what percentage of the bar is filled, should be called anytime the cur or max value is changed.
    /// </summary>
    /// <param name="cur">The current value, the numerator</param>
    /// <param name="max">The max value, the denominator</param>
    public void UpdateBarValue(float cur, float max)
    {
        hpbar.fillAmount = cur / max;
    }
}
