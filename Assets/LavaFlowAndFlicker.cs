using UnityEngine;

public class LavaFlow : MonoBehaviour
{
    public Material lavaMaterial;
    public float flowSpeed = 0.5f;
    public float flickerSpeed = 1.0f;
    public Color minEmissionColor;
    public Color maxEmissionColor;

    private float flowOffset = 0f;
    private float flickerTimer = 0f;

    void Start()
    {
        lavaMaterial = new Material(lavaMaterial);
        GetComponent<Renderer>().material = lavaMaterial;
    }
    void Update()
    {
        // Flow effect
        flowOffset += Time.deltaTime * flowSpeed;
        lavaMaterial.SetTextureOffset("_MainTex", new Vector2(flowOffset, 0));

        // Flicker effect
        flickerTimer += Time.deltaTime * flickerSpeed;
        float lerpFactor = Mathf.Sin(flickerTimer) * 0.5f + 0.5f;
        Color currentEmission = Color.Lerp(minEmissionColor, maxEmissionColor, lerpFactor);
        lavaMaterial.SetColor("_EmissionColor", currentEmission);

        // Ensure emission is enabled
        lavaMaterial.EnableKeyword("_EMISSION");
    }
}

