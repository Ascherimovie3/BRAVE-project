using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audioSource; // Il suono da riprodurre
    public float volume = 1.0f;     // Volume del suono
    public string playerTag = "Player"; // Tag del player

    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = volume; // Imposta il volume iniziale
            audioSource.loop = true;     // Assicura che il suono continui a suonare
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && audioSource != null)
        {
            if (!audioSource.isPlaying) 
            {
                audioSource.Play(); // Inizia a suonare se il player entra e l'audio non è già in riproduzione
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag) && audioSource != null)
        {
            audioSource.Stop(); // Ferma il suono quando il player esce
        }
    }
}

