using UnityEngine;

public class PointLightColorFader : MonoBehaviour
{
    public Color startColor = Color.white;  // Initial color of the light
    public Color endColor = Color.red;      // Target color of the light
    public float fadeDuration = 2f;         // Duration of the fade in seconds

    private Light pointLight;
    private float timer = 0f;

    void Start()
    {
        pointLight = GetComponent<Light>();
        pointLight.color = startColor;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Calculate the interpolation factor between 0 and 1 based on the timer and fade duration
        float t = Mathf.Clamp01(timer / fadeDuration);

        // Interpolate between startColor and endColor
        pointLight.color = Color.Lerp(startColor, endColor, t);

        // Reset the timer and start the fade again when it reaches the duration
        if (timer >= fadeDuration)
        {
            timer = 0f;
            SwapColors();
        }
    }

    void SwapColors()
    {
        // Swap startColor and endColor for the next fade
        Color temp = startColor;
        startColor = endColor;
        endColor = temp;
    }
}
