using System.Collections.Generic;
using UnityEngine;

namespace ColorFigures
{
    public class SetColorFigures : MonoBehaviour
    {
        private static List<Color> _usedColors = new List<Color>();

        private void Start()
        {
            if (gameObject.CompareTag("Sphere"))
            {
                SetRandomColor();
            }
            else if (gameObject.CompareTag("Cube"))
            {
                SetCubeColor();
            }
        }

        private void SetRandomColor()
        {
            Renderer sphereRenderer = GetComponent<Renderer>();

            if (sphereRenderer != null)
            {
                Color randomColor = GetUniqueRandomColor();
                sphereRenderer.material.color = randomColor;
            }
            else
            {
                Debug.LogError("Renderer component not found!");
            }
        }


        private void SetCubeColor()
        {
            Renderer cubeRenderer = GetComponent<Renderer>();

            if (cubeRenderer != null)
            {
                if (gameObject.name == "Cube_Red(Clone)")
                {
                    Color cubeRed = Color.red;
                    cubeRenderer.material.color = cubeRed;
                }
                else if (gameObject.name == "Cube_Green(Clone)")
                {
                    Color cubeRed = Color.green;
                    cubeRenderer.material.color = cubeRed;
                }
            }

            else
            {
                Debug.LogError("Renderer component not found!");
            }
        }

        private Color GetUniqueRandomColor()
        {
            Color randomColor;

            do
            {
                randomColor = new Color(Random.value, Random.value, Random.value);
            } while (_usedColors.Contains(randomColor));

            _usedColors.Add(randomColor);
            return randomColor;
        }
    }
}