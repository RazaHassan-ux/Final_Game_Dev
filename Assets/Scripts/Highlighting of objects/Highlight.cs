using UnityEngine;

public class Highlight : MonoBehaviour
{
    public float maxDistance = 8f;

    private Material mat;
    private Color savedEmission;
    private bool isOn = false;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        // Save whatever emission color is already in Inspector (your gold)
        savedEmission = mat.GetColor("_EmissionColor");

        // Start with emission OFF
        mat.DisableKeyword("_EMISSION");
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform == transform)
            {
                TurnOn();
                return;
            }
        }

        TurnOff();
    }

    void TurnOn()
    {
        if (isOn) return;

        isOn = true;

        // Turn emission ON using your original color
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", savedEmission);
    }

    void TurnOff()
    {
        if (!isOn) return;

        isOn = false;

        // Turn emission OFF
        mat.DisableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", Color.black);
    }
}
