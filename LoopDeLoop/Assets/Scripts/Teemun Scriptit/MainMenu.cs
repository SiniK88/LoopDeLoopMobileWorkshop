using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public AudioClip buttonSFX;
    AudioSource soundOutput;

    void Start() {
        soundOutput = GetComponent<AudioSource>();
        }

    public void QuitGame() {
        Application.Quit();
        Debug.LogError("Game quit!");
        }

    public void ButtonSound() {
        soundOutput.PlayOneShot(buttonSFX);
        }

    }
