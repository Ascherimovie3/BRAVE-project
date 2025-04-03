using UnityEngine;
using UnityEngine.Rendering; // Necessario per cambiare la Skybox

public class ExternalParameterController : MonoBehaviour
{
    [Header("GameObjects per le soglie")]
    public GameObject[] objectsToToggle; // Array di oggetti tra cui alternare

    [Header("Audio del Vento")]
    public AudioSource windAudioSource; // AudioSource per il vento

    [Header("Oscillazione del Ponte")]
    public GameObject bridge; // Il ponte
    private MonoBehaviour bridgeOscillationScript; // Script da attivare/disattivare

    [Header("Skybox")]
    public Material skybox1;
    public Material skybox2;

    private int currentObjectIndex = 0;
    
    void Start()
    {
        // Assicura che solo il primo oggetto sia attivo
        UpdateGameObject(0);

        // Trova automaticamente lo script di oscillazione sul ponte (se esiste)
        if (bridge != null)
        {
            bridgeOscillationScript = bridge.GetComponent<MonoBehaviour>();
        }
    }

    public void UpdateParameters(int threshold)
    {
        Debug.Log("Nuova soglia ricevuta: " + threshold);

        // Cambia GameObject attivo
        UpdateGameObject(threshold % objectsToToggle.Length);

        // Attiva/disattiva il vento
        if (windAudioSource != null)
        {
            windAudioSource.enabled = (threshold % 2 == 0);
        }

        // Attiva/disattiva l'oscillazione del ponte
        if (bridgeOscillationScript != null)
        {
            bridgeOscillationScript.enabled = (threshold % 2 == 1);
        }

        // Cambia Skybox
        RenderSettings.skybox = (threshold % 2 == 0) ? skybox1 : skybox2;
        DynamicGI.UpdateEnvironment(); // Aggiorna l'illuminazione globale
    }

    private void UpdateGameObject(int index)
    {
        if (objectsToToggle.Length == 0) return;

        // Disattiva tutti gli oggetti
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false);
        }

        // Attiva solo quello giusto
        objectsToToggle[index].SetActive(true);
    }
}
