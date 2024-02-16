using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private GameObject pulsePrefab;
    [SerializeField] private float pulseSpeed = 0.5f;
    [SerializeField] private float maxPulseScale = 5f;
    [SerializeField] private float pulseInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnPulseRoutine());
    }

    private IEnumerator SpawnPulseRoutine()
    {
        while (true)
        {
            SpawnPulse();
            yield return new WaitForSeconds(pulseInterval);
        }
    }

    private void SpawnPulse()
    {
        GameObject pulse = Instantiate(pulsePrefab, transform.position, Quaternion.identity, transform);
        StartCoroutine(GrowAndFadePulse(pulse));
    }

    private IEnumerator GrowAndFadePulse(GameObject pulse)
    {
        SpriteRenderer pulseRenderer = pulse.GetComponent<SpriteRenderer>();
        float initialAlpha = pulseRenderer.color.a;

        while (pulse.transform.localScale.x < maxPulseScale)
        {
            pulse.transform.localScale += Vector3.one * pulseSpeed * Time.deltaTime;

            Color pulseColor = pulseRenderer.color;
            pulseColor.a = Mathf.Lerp(initialAlpha, 0f, pulse.transform.localScale.x / maxPulseScale);
            pulseRenderer.color = pulseColor;

            yield return null;
        }

        Destroy(pulse);
    }
}
