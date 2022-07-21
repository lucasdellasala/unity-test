using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors;
    public int colorIndex;

    void Start()
    {
        ChangeMaterialColor(colors[colorIndex]);
    }

    public void ChangeMaterialColor(Color color)
    {
        // Store MeshRenderer
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();

        // Get current material
        Material currentMaterial = mr.material;

        // Duplicate material
        Material material = new Material(currentMaterial);

        // Change color
        material.color = color;

        // Apply new material
        mr.material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        colorIndex++;
        if (colorIndex == colors.Length) colorIndex = 0;

        ChangeMaterialColor(colors[colorIndex]);
    }
    public void SetColor(int index)
    {
        if (index >= colors.Length)
        {
            int times = Mathf.CeilToInt(index / colors.Length);
            index -= colors.Length * times;
        }

        colorIndex = index;
        ChangeMaterialColor(colors[colorIndex]);
    }
}
