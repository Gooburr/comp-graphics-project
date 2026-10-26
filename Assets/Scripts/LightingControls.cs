using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingControls : MonoBehaviour
{
    public Material lightingMaterial;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lightingMaterial.SetFloat("_Diffuse", lightingMaterial.GetFloat("_Diffuse") != 1f ? 1f : 0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lightingMaterial.SetFloat("_Specular", lightingMaterial.GetFloat("_Specular") != 1f ? 1f : 0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            lightingMaterial.SetFloat("_Ambient", lightingMaterial.GetFloat("_Ambient") != 1f ? 1f : 0f);
        }
    }
}
