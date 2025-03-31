using System;
using UnityEngine;

public class CharacterViewYaw : MonoBehaviour {
    [SerializeField] private float initialYaw = 90.0f; // Cambia questo valore per direzionare il player

    private float yaw = 0.0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;  // keep confined to center of screen
        
        // Imposta la rotazione iniziale del player
        yaw = initialYaw;
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    void Update() {
        yaw += Input.GetAxisRaw("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
