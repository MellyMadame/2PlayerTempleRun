using UnityEngine;
using TMPro;
using System.Collections;

public class ChangeFontColorOverTime : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float colorChangeDuration = 2f;

    private void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro object not assigned. Please assign a TextMeshPro object to the script in the Unity Inspector.");
            enabled = false; // Disable the script if the TMP object is not assigned.
            return;
        }

        // Start the color changing loop
        StartCoroutine(ChangeTextColorLoop());
    }

    IEnumerator ChangeTextColorLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ChangeTextColor(Color.blue, Color.magenta));
            yield return StartCoroutine(ChangeTextColor(Color.magenta, Color.blue));
        }
    }

    IEnumerator ChangeTextColor(Color startColor, Color endColor)
    {
        float elapsedTime = 0f;

        while (elapsedTime < colorChangeDuration)
        {
            textMeshPro.color = Color.Lerp(startColor, endColor, elapsedTime / colorChangeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is exactly the end color
        textMeshPro.color = endColor;
    }
}
