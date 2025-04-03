using UnityEngine;

public class RotationOscillation : MonoBehaviour
{
    public float amplitude = 10f; // Massimo angolo di rotazione (in gradi)
    public float frequency = 1f;  // Velocità dell'oscillazione

    private float startRotationZ;

    void Start()
    {
        startRotationZ = transform.eulerAngles.z; // Salva la rotazione iniziale
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * frequency) * amplitude; // Oscillazione sinusoidale
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, startRotationZ + angle);
    }
}

