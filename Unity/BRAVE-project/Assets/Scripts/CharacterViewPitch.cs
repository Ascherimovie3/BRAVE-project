using System;
using UnityEngine;

public class CharacterViewPitch : MonoBehaviour {
    [SerializeField] private float MinPitch = -60;
    [SerializeField] private float MaxPitch = 60;
    [SerializeField] private float initialPitch = 0f; // Imposta l'angolo iniziale della camera

    private float pitch = 0.0f;

    void Start() {
        // Imposta l'angolazione iniziale della camera
        pitch = initialPitch;
        transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
    }

    void Update() {
        float prev_pitch = pitch;

        pitch -= Input.GetAxisRaw("Mouse Y");
        pitch = ClampAngle(pitch, MinPitch, MaxPitch); // Usa il metodo ClampAngle
        transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
    }

    private float ClampAngle(float angle, float min, float max) {
        return Mathf.Clamp(angle, min, max);
    }
}


