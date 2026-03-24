using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float duration = 1.5f;

    public float magnitude = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;

            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
