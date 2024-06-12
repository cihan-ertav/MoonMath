using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    public SpriteRenderer isik;
    public float maxAlpha = 1.0f; // Maksimum alpha değeri
    public float minAlpha = 0.0f; // Minimum alpha değeri

    // Işık hüzmesini etkinleştir
    public void ActivateLightBeam()
    {
        StartCoroutine(FadeLightBeam(maxAlpha));
    }

    // Işık hüzmesini devre dışı bırak
    public void DeactivateLightBeam()
    {
        StartCoroutine(FadeLightBeam(minAlpha));
    }

    // Işık hüzmesinin saydamlığını değiştiren coroutine
    IEnumerator FadeLightBeam(float targetAlpha)
    {
        float currentAlpha = isik.color.a;

        // Zamanla alpha değerini değiştir
        while (currentAlpha != targetAlpha)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * 0.5f); // Hızı ayarlayabilirsiniz
            isik.color = new Color(1, 1, 1, currentAlpha);
            yield return null;
        }
    }
    
}
