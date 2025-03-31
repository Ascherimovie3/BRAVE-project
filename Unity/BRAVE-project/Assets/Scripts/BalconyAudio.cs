using UnityEngine;

public class BalconyAudio : MonoBehaviour {
    public AudioSource audioSource;
    public Transform player;
    public float maxVolume = 3.0f;
    public float minVolume = 0.05f;
    public float transitionSpeed = 1.0f; 

    private void Update() {
        float distance = Vector3.Distance(player.position, transform.position);

        float targetVolume = (distance < 6.5) ? maxVolume : minVolume;
        
        audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, Time.deltaTime * transitionSpeed);
    }
}

